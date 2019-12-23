using AutoMapper;
using DatingApp.Dtos;
using DatingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<User, UserForListDto>()
             .ForMember(dest => dest.PhotoUrl, opt =>
                opt.MapFrom(src => 
                src.Photos.FirstOrDefault(p => p.IsMain).Url))

             .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src =>
                src.DateOfBirth.CalculateAge()));

            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                opt.MapFrom(src =>
                src.Photos.FirstOrDefault(p => p.IsMain).Url))

             .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src =>
                src.DateOfBirth.CalculateAge()));

            CreateMap<Photo, PhotosForDetailedDto>();

        }
    }
}
