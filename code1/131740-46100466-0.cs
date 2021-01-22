        public static object SingleOrDefault(this IEnumerable enumerable, Type type)
        {
            var method = singleOrDefaultMethod.Value.MakeGenericMethod(new[] { type });
            return method.Invoke(null, new[] { enumerable });
        }
        private static Lazy<MethodInfo> singleOrDefaultMethod 
             = new Lazy<MethodInfo>(() =>
                 typeof(Extensions).GetMethod(
                     "SingleOrDefault", BindingFlags.Static | BindingFlags.NonPublic));
        private static T SingleOrDefault<T>(IEnumerable<T> enumerable)
        {
            return enumerable.SingleOrDefault();
        }
