    using AutoMapper;
    using System;
    using System.Collections.Generic;
    
    namespace ConsoleAppTest2
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Mapper.Initialize(cfg => {
                    //Using specific type converter for specific arrays
                    cfg.CreateMap<Foo[], FooDto[]>().ConvertUsing(new ArrayFilterTypeConverter<Foo[], FooDto[], Foo, FooDto>(
                                                                                                                   (src, dest) => (src.Age > 0)
                                                                                                                ));
    
                    cfg.CreateMap<Foo, FooDto>()
                        .ForMember(dest => dest.Age, opt => opt.Condition(src => (src.Age >= 0)))
                        .ForMember(dest => dest.CurrentAddress, opt =>
                                                                    {
                                                                        opt.Condition(src => (src.Age >= 0));
                                                                        opt.MapFrom(src => src.Address);
                                                                    });
    
                });
    
                var foo = new Foo() { Name = "Name", Address = "Address", Age = -1 };
                var fooDTO = new FooDto();
    
    
                var fooArray = new Foo[] {
                        new Foo() { Name = "Name1", Address = "Address1", Age = -1 },
                        new Foo() { Name = "Name2", Address = "Address2", Age = 1 },
                        new Foo() { Name = "Name3", Address = "Address3", Age = 1 }
                };
    
                var fooDTOArray =  Mapper.Map<Foo[], FooDto[]>(fooArray); //get 2 elements instead of 3
    
                Mapper.Map(foo, fooDTO);
                //The result is we skipped Address and Age properties becase Age is negative
    
                Console.ReadLine();
            }
        }
    
        public class ArrayFilterTypeConverter<TSourceArray, TDestArray, TSource, TDest> : ITypeConverter<TSourceArray, TDestArray>
        {
            private Func<TSource, TDest, bool> filter;
    
            public ArrayFilterTypeConverter(Func<TSource, TDest, bool> filter)
            {
                this.filter = filter;
            }
    
            public TDestArray Convert(TSourceArray source, TDestArray destination, ResolutionContext context)
            {
                var sourceArray = source as TSource[];
                List<TDest> destList = new List<TDest>();
    
                var typeMap = context.ConfigurationProvider.ResolveTypeMap(typeof(TSource), typeof(TDest));
    
                foreach (var src in sourceArray)
                {
                    var dest = context.Mapper.Map<TSource, TDest>(src);
    
                    if (filter(src, dest))
                        destList.Add(dest);
                }
                
                // Little hack to cast array to TDestArray
                var result = (TDestArray)(object)destList.ToArray();
                return result;
            }
        }
    
        internal class FooDto
        {
            public string Name { get; set; }
            public string CurrentAddress { get; set; }
            public int Age { get; set; }
    
        }
    
        internal class Foo
        {
            public string Name { get; set; }
            public string Address { get; set; }
    
            public int Age { get; set; }
        }
    }
