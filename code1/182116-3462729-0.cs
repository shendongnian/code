    // non-generic factory class with generic methods
    public static class Lazy {
        public static Lazy<T> Create<T>() where T : new() {
            return Create<T>(() => new T());
        }
        public static Lazy<T> Create<T>(Func<T> ctor) { ... }
    }
    public class Lazy<T> { ... }
