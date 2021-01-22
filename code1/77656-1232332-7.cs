    public static class Circumventions
    {
        public static IList<T> AsWritable<T>(this IEnumerable<T> source)
        {
            return (IList<T>)source.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | 
                           BindingFlags.Instance)
                .Select(f => f.GetValue(source))
                .First(v => (v as IList<T>) != null);
        }
    }
