    public sealed class Async<T> { internal T value; }
    public static class Async
    {
       public static Async<Future<T>> Begin<T>(Future<T> future) { ... }
    }
