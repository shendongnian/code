    public class A
    {
        public List<string> MyList {get; set;}
    }
    
    public class B: RealmObject
    {
        public IList<string> MyList {get;}
    }
    
    var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<A, B>()
                .ForMember(dest => dest.MyList, opt =>
                {
                     opt.UseDestinationValue();
                     opt.MapFrom(src => src.MyList);
                });
        }
