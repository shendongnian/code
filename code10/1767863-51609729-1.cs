    public static class Extension
    {
        public static IPagedList<TDestination> ToMappedPagedList<TSource, TDestination>(this IPagedList<TSource> list)
        {
            IMapper mapper = MapperConfig.Mapper;
          
            IEnumerable<TDestination> sourceList = mapper.Map<IEnumerable<TDestination>>(list);
            IPagedList<TDestination> pagedResult = new StaticPagedList<TDestination>(sourceList, list.GetMetaData());
           
            return pagedResult;
        }
        public static IEnumerable<TDestination> Map<TSource, TDestination>(this IEnumerable<TSource> list)
            where TSource : class
            where TDestination : class, new()
        {
            IMapper mapper = MapperConfig.Mapper;
            IEnumerable<TDestination> sourceList = mapper.Map<IEnumerable<TDestination>>(list);
            return sourceList;
        }
        public static TDestination Map<TSource, TDestination>(this TSource entity)
            where TSource : class
            where TDestination : class, new()
        {
            IMapper mapper = MapperConfig.Mapper;
            return mapper.Map<TDestination>(entity);
        }
    }
