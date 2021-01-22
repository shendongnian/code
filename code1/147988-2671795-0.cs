    public static class Extensions
    {
        public static IEnumerable<T> Rotate<T>(this IEnumerable<T> enuml)
        {
            var count = enuml.Count();
            return enuml
                .Skip(count - 1)
                .Concat(enuml.Take(count - 1));
        }
        public static IEnumerable<T> SkipAndRotate<T>(this IEnumerable<T> enuml)
        {
            return enum
                .Take(1)
                .Concat(
                    enuml.Skip(1).Rotate()
                );
        }
    }
    
