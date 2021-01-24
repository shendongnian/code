    public static class IMapperConfigurationExpressionExtensions 
    {
    	public static void MapPaggedResults<TSource, TDestination>(this IMapperConfigurationExpression exp){
    		exp.CreateMap(typeof(PaggedResults<TSource>), typeof(IPaggedResults<TDestination>))
    	   .ConstructUsing((source, ctx) => { return ctx.Mapper.Map<PaggedResults<TDestination>>(source) as IPaggedResults<TDestination>; });
    	}
    }
