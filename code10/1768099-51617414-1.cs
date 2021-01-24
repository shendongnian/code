    using AutoMapper;
    using System;
    
    namespace ConsoleAppTest2
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                Mapper.Initialize(cfg => {
    
                    cfg.CreateMap<Foo, FooDto>()
                        .ForMember(dest => dest.Age, opt => opt.Condition(src => (src.Age >= 0)))
                        .ForMember(dest => dest.Address, opt => opt.Condition(src => (src.Age >= 0)));
                    
                });
    
                var foo = new Foo() { Name = "Name", Address = "Address", Age = -1 };
                var fooDTO = new FooDto();
    
                Mapper.Map(foo, fooDTO);
                //The result is we skipped Address and Age properties becase Age is negative
    
                Console.ReadLine();
            }
        }
    
        internal class FooDto
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public int Age { get; set; }
    
        }
    
        internal class Foo
        {
            public string Name { get; set; }
            public string Address { get; set; }
    
            public int Age { get; set; }
        }
    }
