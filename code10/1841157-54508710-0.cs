c#
using AutoMapper;
using System;
using System.Collections.Generic;
namespace ConsoleAppMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pet, Dto.Pet>()
                    .Include<Pet, Dto.Dog>()
                    .Include<Pet, Dto.Cat>()
                    .Include<Pet, Dto.Mouse>()
                    .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.PetName))
                    .ForMember(dst => dst.Description, opt => opt.Ignore())
                    .ConstructUsing((src, context) =>
                    {
                        switch (src.Type)
                        {
                            case 1: return context.Mapper.Map(src, new Dto.Dog { }, context);
                            case 2: return context.Mapper.Map(src, new Dto.Cat { }, context);
                            case 3: return context.Mapper.Map(src, new Dto.Mouse { }, context);
                            default: return context.Mapper.Map(src, new Dto.Pet { }, context);
                        }
                    })
                ;
                cfg.CreateMap<Pet, Dto.Dog>()
                    .ForMember(dst => dst.Description, opt => opt.MapFrom(src => "This is a dog"))
                ;
                cfg.CreateMap<Pet, Dto.Cat>()
                    .ForMember(dst => dst.Description, opt => opt.MapFrom(src => "This is a cat"))
                ;
                cfg.CreateMap<Pet, Dto.Mouse>()
                    .ForMember(dst => dst.Description, opt => opt.MapFrom(src => "This is a mouse"))
                ;
            }).CreateMapper();
            // Test
            var pets = new List<Pet>
            {
                new Pet { PetName = "Bob", Type = 1 },
                new Pet { PetName = "Tom", Type = 2 },
                new Pet { PetName = "Jerry", Type = 3 },
                new Pet { PetName = "Duffy", Type = 4 },
            };
            // Full mixed collection
            var dtoList = mapper.Map<IEnumerable<Pet>, IEnumerable<Dto.Pet>>(pets);
            // Single item
            var dog = mapper.Map<Pet, Dto.Pet>(pets[0]); 
            var dog2 = mapper.Map<Pet, Dto.Dog>(pets[0]); 
        }
    }
    public class Pet
    {
        public string PetName;
        public int Type;
    }
}
namespace Dto
{
    public class Pet
    {
        public string Name;
        public string Description;
    }
    public class Dog : Pet
    {
    }
    public class Cat : Pet
    {
    }
    public class Mouse : Pet
    {
    }
}
