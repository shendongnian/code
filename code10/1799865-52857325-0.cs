        public static System.Linq.IQueryable Include(this System.Linq.IQueryable source, string navigationPropertyPath)
        {
            var entityType = source.GetType().GetGenericArguments().Single();
            var includeMethodGenericDefinition = typeof(Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions).GetMethods()
                                                    .Where(m => m.Name == "Include")
                                                    .Where(m => m.GetParameters()[1].ParameterType == typeof(string))
                                                    .Single();
            var includeMethod = includeMethodGenericDefinition.MakeGenericMethod(entityType);
            return (IQueryable)includeMethod.Invoke(null, new object[] { source, navigationPropertyPath });
        }
