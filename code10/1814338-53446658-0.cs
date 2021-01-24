    public Entity GetByPropertyValue<T>(string propertyName, T value)
    {
        var p = Expression.Parameter(typeof(Entity));
        var body = Expression.Equal(
            Expression.PropertyOrField(p, propertyName),
            Expression.Constant(value, typeof(T)));
        var lambda = Expression.Lambda<Func<Entity, bool>>(body, p);
        return OrganizationContext.CreateQuery("contact").Where(lambda).FirstOrDefault();
    }
