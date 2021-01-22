     public static IEnumerable<T> Sort<T>(this IEnumerable<T> source, string sortExpression, bool desc)
        {
            var param = Expression.Parameter(typeof(T), string.Empty);
            try
            {
                var fields = sortExpression.Split('.');
                Expression property = null;
                Expression parentParam = param;
                foreach (var field in fields)
                {
                    property = Expression.Property(parentParam, field);
                    parentParam = property;
                }
                var sortLambda = 
                    Expression.Lambda<Func<T, object>>(
                      Expression.Convert(property, typeof(object)), param);
                if (desc)
                {
                    return source.AsQueryable<T>().
                         OrderByDescending<T, object>(sortLambda);
                }
                return source.AsQueryable<T>().
                     OrderBy<T, object>(sortLambda);
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
