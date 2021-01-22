    static class EntityExtensions {
        public static void SomeMethod<T>(this T obj)
              where T : class, IFunkyInterface
        {...}
    }
