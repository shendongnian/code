    ef.Entities.Where(ContainsPredicate<Entity, string>(arr, "Name")).ToArray();
    public Expression<Func<TEntity, bool>> ContainsPredicate<TEntity, T>(T[] arr, string fieldname) where TEntity : class {
      ParameterExpression entity = Expression.Parameter(typeof(TEntity), "entity");
      MemberExpression member = Expression.Property(entity, fieldname);
      var containsMethods = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
      .Where(m => m.Name == "Contains");
      MethodInfo method = null;
      foreach (var m in containsMethods) {
        if (m.GetParameters().Count() == 2) {
          method = m;
          break;
        }
      }
      method = method.MakeGenericMethod(member.Type);
      var exprContains = Expression.Call(method, new Expression[] { Expression.Constant(arr), member });
      return Expression.Lambda<Func<TEntity, bool>>(exprContains, entity);
    }
