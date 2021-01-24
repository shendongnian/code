    public static Expression<Func<Notification, bool>> CreateWherExpression(
        string propertyName, string filterValue)
    {
        var notificationType = typeof(Notification);
        var entity = Expression.Parameter(notificationType, "entity");
        var body = Expression.Equal(
            Expression.Property(entity, propertyName),
            Expression.Constant(filterValue));
        return Expression.Lambda<Func<Notification, bool>>(body, entity);
    }
