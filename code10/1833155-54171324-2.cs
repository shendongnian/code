    static class Serializer
    {
        static int DoSomething(string value, Stream stream) => value.Length;
        static int DoSomethingElse<T>(T[] values, Stream stream) => values.Length;
    
        public static Func<T, Stream, int> GetSerializer<T>()
        {
            var firstProperty = typeof(T).GetProperties().First();
            var item = Expression.Parameter(typeof(T));
            var stream = Expression.Parameter(typeof(Stream));
            var propType = firstProperty.PropertyType;
            if (typeof(string).IsAssignableFrom(propType))
            {
                var body = Expression.Call(
                    typeof(Serializer),
                    "DoSomething",
                    Type.EmptyTypes,
                    Expression.Invoke(
                        MakeGetter(firstProperty),
                        item
                    ),
                    stream
                );
                return Expression.Lambda<Func<T, Stream, int>>(body, item, stream).Compile();
            }
            if (typeof(Array).IsAssignableFrom(propType))
            {
                var body = Expression.Call(
                    typeof(Serializer),
                    "DoSomethingElse",
                    new[] { propType.GetElementType() },
                    Expression.Invoke(
                        MakeGetter(firstProperty),
                        item
                    ),
                    stream
                );
                return Expression.Lambda<Func<T, Stream, int>>(body, item, stream).Compile();
            }
            return (T arg0, Stream arg1) => 0;
        
            Expression MakeGetter(PropertyInfo prop)
            {
                var arg0 = Expression.Parameter(typeof(T));
                return Expression.Lambda(
                    Expression.Property(arg0, prop),
                    arg0
                );
            }
        }
    }
