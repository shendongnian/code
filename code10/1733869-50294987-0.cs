    public static IQueryable<T> SelectExcept<T, TKey>(this IQueryable<T> sequence, Expression<Func<T, TKey>> excluder)
        {
            List<PropertyInfo> properties = new List<PropertyInfo>();
    
            var exProp = (excluder.Body as MemberExpression).Member.Name;
            var incProps = typeof(T).GetProperties().Where(p => p.Name != exProp);
            foreach (var prop in incProps)
                properties.Add(prop);
    
            return sequence.Select(x => Selector(x, properties));
        }
    
        private static T Selector<T>(T arg, List<PropertyInfo> properties) 
        {
            var instance = Activator.CreateInstance(typeof(T));
            foreach (var property in properties)
            {
                property.SetValue(instance, property.GetValue(arg), null);
            }
            return (T)instance;
        }
