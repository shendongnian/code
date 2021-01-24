        public static IQueryable Set(this DbContext context, Type T)
        {
            // Get the generic type definition
            MethodInfo method =
                typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);
            // Build a method with the specific type argument you're interested in
            method = method.MakeGenericMethod(T);
            return method.Invoke(context, null) as IQueryable;
        }
        public static IEnumerable<object> FindAll(this DbContext context, Type T, IEnumerable<object> ids)
        {
            // Set the base entity (T) parameter for the lambda and property expressions
            var xParameter = Expression.Parameter(T, "a");
            // Retrieve the primary key name from the model and set the property expression
            var primaryKeyName = context.Model.FindEntityType(T).FindPrimaryKey().Properties.First().Name;
            var xId = Expression.Property(xParameter, primaryKeyName);
            var idType = xId.Type;
            // Set the constant expression with the list of id you want to search for
            var xIds = Expression.Constant(ids, typeof(IEnumerable<object>));
            // Create the Expression call for the CastEnumerable extension method below 
            var xCastEnumerable = Expression.Call(typeof(IEnumerableExtensions), "CastEnumerable",new[]{idType},xIds);
            // Create the expression call for the "Contains" method that will be called on the list
            // of id that was cast just above with the id property expression as the parameter
            var xContainsMethod = Expression.Call(typeof(Enumerable), "Contains",new[]{idType},xCastEnumerable, xId);
            // Create a lambda expression with the "Contains" expression joined with the base entity (T) parameter
            var xWhereLambda = Expression.Lambda(xContainsMethod, xParameter);
            // Get the "Queryable.Where" method info
            var whereMethodInfo = typeof(Queryable).GetMethods().SingleOrDefault(x => x.Name.Equals("Where") && x.GetParameters()[1].ParameterType.GetGenericType().GenericTypeArguments.Length == 2).MakeGenericMethod(T);
            // Call the where method on the DbSet<T> with the lambda expression that compares the list of id with the entity's Id
            return whereMethodInfo.Invoke(null, new object[] {context.Set(T),xWhereLambda}) as IEnumerable<object>;
        }
