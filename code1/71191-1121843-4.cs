                var item = typeof(MyType).GetInterfaces()
                                .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IList<>))
                                .Select(t => t.GetGenericArguments().First())
                                .FirstOrDefault();
    if( item != null )
     //it has a type
