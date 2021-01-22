    public class Tuple { }
    public class Tuple<T0> : Tuple { }
    public class Tuple<T0, T1> : Tuple<T0> { }
    public class Caller<TTuple> where TTuple : Tuple { /* ... */ }
    public static class CallerExtensions
    {
         public static void Call<T0>(this Caller<Tuple<T0>> caller, T0 p0) { /* ... */ }
         public static void Call<T0, T1>(this Caller<Tuple<T0, T1>> caller, T0 p0, T1 p1) { /* ... */ }
    }
    new Caller<Tuple<int>>().Call(10);
    new Caller<Tuple<string, int>>().Call("Hello", 10);
