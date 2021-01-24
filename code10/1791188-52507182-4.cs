    using System;
    using System.Linq.Expressions;
    public interface IQ<T> {}
    public class E
    {
        public IQ<X> C { get; set; }
    }
    public class X
    {
        public int P { get; set; }
    }
    public class Program
    {
        public static IQ<R> S<T, R>(IQ<T> q, Expression<Func<T, R>> f) { return null; }
        public static void Main()
        {
            Expression<Func<E, IQ<int>>> f  = e => S<X, int>(e.C, c => c.P);
        }
    }
