    public class SortingOption<T> where T: class
    {
        private MethodInfo ascendingMethod;
        private MethodInfo descendingMethod;
        private LambdaExpression lambda;
        public string Name { get; private set; }
        public SortDirection DefaultDirection { get; private set; }
        public bool ApplyByDefault { get; private set; }
        public SortingOption(PropertyInfo targetProperty, SortableAttribute options)
        {
            Name = targetProperty.Name;
            DefaultDirection = options.Direction;
            ApplyByDefault = options.IsDefault;
            var utilitiesClass = typeof(SortingUtilities<,>).MakeGenericType(typeof(T), targetProperty.PropertyType);
            ascendingMethod = utilitiesClass.GetMethod("ApplyOrderBy", BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase);
            descendingMethod = utilitiesClass.GetMethod("ApplyOrderByDescending", BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase);
            var param = Expression.Parameter(typeof(T));
            var getter = Expression.MakeMemberAccess(param, targetProperty);
            lambda = Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(T), targetProperty.PropertyType), getter, param);
        }
        public IQueryable<T> Apply(IQueryable<T> query, SortDirection? direction = null)
        {
            var dir = direction.HasValue ? direction.Value : DefaultDirection;
            var method = dir == SortDirection.Ascending ? ascendingMethod : descendingMethod;
            return (IQueryable<T>)method.Invoke(null, new object[] { query, lambda });
        }
    }
