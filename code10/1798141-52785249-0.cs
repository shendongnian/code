    public static Expression<Func<TEntity, TDto>> InitInhertedProperties<TEntity, TDto>() where TDto : TEntity
    {
        var entity = Expression.Parameter(typeof(BusinessObject), "b");
        var newDto = Expression.New(typeof(Dto).GetConstructors().First());
        var body = Expression.MemberInit(newDto,
            typeof(TDto).GetProperties()
                .Select(p => Expression.Bind(p, Expression.Property(entity, p.Name)))
          );
        return Expression.Lambda<Func<TEntity, TDto>>(body, entity);
    }
