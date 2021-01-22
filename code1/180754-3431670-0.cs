    public Predicate<Feature> GetFilter<T>(
        Expression<Func<Feature, T>> property,
        T value,
        string condition)
    {
        switch (condition)
        {
        case ">=":
            return
                Expression.Lambda<Predicate<Feature>>(
                    Expression.GreaterThanOrEqual(
                        property.Body,
                        Expression.Constant(value)
                    ),
                    property.Parameters
                ).Compile();
        default:
            throw new NotSupportedException();
        }
    }
