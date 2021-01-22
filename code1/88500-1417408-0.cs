      /// <summary>
      /// Gets the name of a property without having to write it as string into the code.
      /// </summary>
      /// <param name="instance">The instance.</param>
      /// <param name="expr">An expression like "x => x.Property"</param>
      /// <returns>The name of the property as string.</returns>
      public static string GetPropertyName<T, TProperty>(this T instance, Expression<Func<T, TProperty>> expr)
            {
                var memberExpression = expr.Body as MemberExpression;
                return memberExpression != null
                    ? memberExpression.Member.Name
                    : String.Empty;
            }
