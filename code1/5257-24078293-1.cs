    public static class ObjectInstanceExtensions
    {
        private static Dictionary<object, string> namedInstances = new Dictionary<object, string>();
        public static void Named<T>(this T instance, Expression<Func<T>> expressionContainingOnlyYourInstance)
        {
            var name = ((MemberExpression)expressionContainingOnlyYourInstance.Body).Member.Name;
            instance.Named(name);            
        }
        public static T Named<T>(this T instance, string named)
        {
            if (namedInstances.ContainsKey(instance)) namedInstances[instance] = named;
            else namedInstances.Add(instance, named);
            return instance;
        }        
        
        public static string Name<T>(this T instance)
        {
            if (namedInstances.ContainsKey(instance)) return namedInstances[instance];
            throw new NotImplementedException("object has not been named");
        }        
    }
