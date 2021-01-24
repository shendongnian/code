      public static Expression<Func<TEntity, string>> CreateEnumDescriptionExpression<TEntity, TEnum>(
        Expression<Func<TEntity, TEnum>> propertyExpression)
         where TEntity : class
         where TEnum : struct
      {
         // Get all of the possible enum values for the given enum type
         var enumValues = Enum.GetValues(typeof(TEnum)).Cast<Enum>();
         // Build up a condition expression based on each enum value
         Expression resultExpression = Expression.Constant(string.Empty);
         foreach (var enumValue in enumValues)
         {
            resultExpression = Expression.Condition(
               Expression.Equal(propertyExpression.Body, Expression.Constant(enumValue)),
               // GetDescription() can be replaced with whatever extension 
               // to get you the needed enum attribute.
               Expression.Constant(enumValue.GetDescription()),
               resultExpression);
         }
         return Expression.Lambda<Func<TEntity, string>>(
            resultExpression, propertyExpression.Parameters);
      }
