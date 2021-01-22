    public static class Circumventions
    {
        public static IList<T> AsWritable<T>(this IEnumerable<T> source)
        {
            return (IList<T>)source.GetType()
                .GetFields(System.Reflection.BindingFlags.NonPublic |
                           System.Reflection.BindingFlags.Instance)
                .First(f => typeof(IList<T>).IsAssignableFrom(f.FieldType))
                .GetValue(source);
        }
    }
