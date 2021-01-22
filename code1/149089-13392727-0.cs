    public class UniqueAttribute : ValidationAttribute
    {
        public UniqueAttribute(Type dataContextType, Type entityType, string propertyName)
        {
            DataContextType = dataContextType;
            EntityType = entityType;
            PropertyName = propertyName;
        }
        public Type DataContextType { get; private set; }
        public Type EntityType { get; private set; }
        public string PropertyName { get; private set; }
        public override bool IsValid(object value)
        {
            // Construct the data context
            //ConstructorInfo constructor = DataContextType.GetConstructor(new Type[0]);
            //DataContext dataContext = (DataContext)constructor.Invoke(new object[0]);
            var repository = DependencyResolver.Current.GetService(DataContextType);
            var data = repository.GetType().InvokeMember("GetAll", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public, null, repository, null);
            // Get the table
            //ITable table = dataContext.GetTable(EntityType);
            // Get the property
            PropertyInfo propertyInfo = EntityType.GetProperty(PropertyName);
            // Our ultimate goal is an expression of:
            //   "entity => entity.PropertyName == value"
            // Expression: "value"
            object convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
            var rhs = Expression.Constant(convertedValue);
            // Expression: "entity"
            var parameter = Expression.Parameter(EntityType, "entity");
            // Expression: "entity.PropertyName"
            var property = Expression.MakeMemberAccess(parameter, propertyInfo);
            // Expression: "entity.PropertyName == value"
            var equal = Expression.Equal(property, rhs);
            // Expression: "entity => entity.PropertyName == value"
            var lambda = Expression.Lambda(equal, parameter).Compile();
           
            // Instantiate the count method with the right TSource (our entity type)
            MethodInfo countMethod = QueryableCountMethod.MakeGenericMethod(EntityType);
            // Execute Count() and say "you're valid if you have none matching"
            int count = (int)countMethod.Invoke(null, new object[] { data, lambda });
            return count == 0;
        }
        // Gets Queryable.Count<TSource>(IQueryable<TSource>, Expression<Func<TSource, bool>>)
        //private static MethodInfo QueryableCountMethod = typeof(Enumerable).GetMethods().First(m => m.Name == "Count" && m.GetParameters().Length == 2);
        private static MethodInfo QueryableCountMethod = typeof(System.Linq.Enumerable).GetMethods().Single(
            method => method.Name == "Count" && method.IsStatic && method.GetParameters().Length == 2);
    }
