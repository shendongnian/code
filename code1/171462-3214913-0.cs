    Func<object, InlineCollection> GetInlinesFunction(Type type)
    {
        string propertyName = ...;
        // ^ check whether type has a ContentPropertyAttribute and
        // retrieve its Name here, or null if there isn't one.
        if (propertyName == null)
            return null;
        var p = Expression.Parameter(typeof(object), "it");
        // The following creates a delegate that takes an object
        // as input and returns an InlineCollection (as long as
        // the object was at least of runtime-type "type".
        return Expression.Lambda<Func<object, InlineCollection>>(
            Expression.Property(
                Expression.Convert(p, type),
                propertyName),
            p).Compile();
    }
