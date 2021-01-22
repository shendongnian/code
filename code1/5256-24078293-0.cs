    public static class ObjectInstanceExtensions
    {
        private static Dictionary<object, string> namedInstances = new Dictionary<object, string>();
        public static void Named<T>(this T instance, Expression<Func<T>> expressionContainingOnlyYourInstance)
        {
            var name = ((MemberExpression)expressionContainingOnlyYourInstance.Body).Member.Name;            
            if (namedInstances.ContainsKey(instance)) namedInstances[instance] = name;
            else namedInstances.Add(instance, name);            
        }
        
        public static string Name<T>(this T instance)
        {
            if (namedInstances.ContainsKey(instance)) return namedInstances[instance];
            throw new NotImplementedException("object instance has not been named");
        }
    }
