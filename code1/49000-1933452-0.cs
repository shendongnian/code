    public static class Recursive {
                public static Func<R> Func<R>(
                    Func<Func<R>, Func<R>> f) { 
                    return () => f(Func(f))(); }
                public static Func<T1, R> Func<T1, R>(
                    Func<Func<T1, R>, Func<T1, R>> f) { 
                    return x => f(Func(f))(x); }
                public static Func<T1, T2, R> Func<T1, T2, R>(
                    Func<Func<T1, T2, R>, Func<T1, T2, R>> f) {
                    return (a1, a2) => f(Func(f))(a1, a2);
                }
                //And so on...
            }
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(
                Recursive.Func<int, int>(factorial =>
                    x => x == 0 ? 1 : factorial(x - 1) * x
                ) 
                (10)
            );
            Console.WriteLine(
                Recursive.Func<int,int,int>(gcd =>
                    (x,y) => 
                        x == 0 ? y:
                        y == 0 ? x:
                        x > y  ? gcd(x % y, y):
                        gcd(y % x, x)
                )
                (35,21)
            );
        }
    }
