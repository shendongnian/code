    Model.GetType().GetProperties().Where( p =>
        p.PropertyType.GetInterfaces().Any( i =>
            i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IEnumerable<>)
        )
    );
