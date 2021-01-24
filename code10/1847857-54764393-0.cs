    public static class QueryableExtensions2
    {
        public static IQueryable<TModel> Map<TModel>(
            this IQueryable query, Func<dynamic, TModel> mapping)
        {
            var tdto = query.ElementType;
            var typedMapping =
                typeof(QueryableExtensions2).GetMethod(nameof(Wrap))
                                            .MakeGenericMethod(tdto, typeof(TModel))
                                            .Invoke(null, new object[] { mapping });
            var targetType = typeof(ProviderAdapter<,>)
                                 .MakeGenericType(tdto, typeof(TModel));
            var instance = Activator.CreateInstance(targetType,
                                                    new object[] { query, typedMapping });
            return (IQueryable<TModel>)instance;
        }
        static public Func<TDto, TModel> Wrap<TDto, TModel>(Func<dynamic, TModel> mapping) =>
            d => mapping(d);
    }
