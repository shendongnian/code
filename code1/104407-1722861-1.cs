    public static class ReflectionExtensions
    {
        public static T CreateInstance<T>(this Type source, params object[] objects)
            where T : class
        {            
            var cons = source.GetConstructor(objects.Select(x => x.GetType()).ToArray());
            return cons == null ? null : (T)cons.Invoke(objects);
        }
    }
