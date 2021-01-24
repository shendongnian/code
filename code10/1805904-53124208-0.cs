        public class SourceClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<SourceNestedClass> SourceNestedClasses { get; set; }
            public SourceClass()
            {
                SourceNestedClasses = new List<SourceNestedClass>();
            }
        }
    
        public class SourceNestedClass
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    
    
        public class DestNestedClass
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName { get; set; }
        }
    
        public class DestinationClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<DestNestedClass> Nesteds { get; set; }
    
            public DestinationClass()
            {
                Nesteds = new List<DestNestedClass>();
            }
        }
    
        class Program
        {
    
    
            public static DestinationClass MapAutomatically(SourceClass sourceInfo)
            {
    
    
                var config = new MapperConfiguration(cfg =>
                {
                    //mapping parent classes with nested classes
                    cfg.CreateMap<SourceClass, DestinationClass>()
                    .ForMember(dest => dest.Nesteds, opt => opt.MapFrom(source => source.SourceNestedClasses));
    
                    //mapping classes
                    cfg.CreateMap<SourceNestedClass, DestNestedClass>()
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(source => source.FirstName + source.LastName));
                });
    
                var mapper = config.CreateMapper();
                var destResult = mapper.Map<SourceClass, DestinationClass>(sourceInfo);
    
                return destResult;
    
            }
    
    
            static void Main(string[] args)
            {
    
                var sourceInfo = new SourceClass
                {
                    Id = 5,
                    Name = "SourceClass",
                    SourceNestedClasses = { new SourceNestedClass { Id = 10, FirstName = "Test", LastName = "Address" } }
                };
    
                var destResult = MapAutomatically(sourceInfo);
            }
        }
    }
