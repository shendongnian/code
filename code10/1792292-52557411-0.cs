    class Foo
    {
         public string Name { get; set; }
    }
    class Bar
    {
        public string Name { get; set; }
    }
    static void Main(string[] args)
    {
        IMyMapper _myMapper = MapperHelper.GetMapperFor<Foo, Bar>();
        Bar _bar = _myMapper.MapFrom<Bar>(new Foo() { Name = "aaaAAA" });
    }
    public interface IMyMapper
    {
        T MapFrom<T>(object entity);
    }
    class MyMapper : IMyMapper
    {
          IMapper mapper;
          public MyMapper(IMapper mapper)
          {
                this.mapper = mapper;
          }
          public T MapFrom<T>(object entity)
          {
               return mapper.Map<T>(entity);
          }
    }
    public static class MapperHelper
    {
         static IMapper staticMapper;
        static MapperHelper()
        {
             var config = new MapperConfiguration(cfg => {
             cfg.CreateMap<Foo, Bar>();
             });
            staticMapper = config.CreateMapper();
         }
         //First approach, create a mapper and use it from a static method
         public static T MapFrom<T>(object entity)
         {
               return staticMapper.Map<T>(entity);
         }
         //Second approach (if users need to use their own types which are not known by this project)
         //Create you own mapper interface ans return it
         public static IMyMapper GetMapperFor<TSource, TDestination>()
         {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<TSource, TDestination>();
                });
                var _mapper = config.CreateMapper();
                return new MyMapper(_mapper);
         }
     }
