    using System;
    using System.Linq.Expressions;
    public class C<TSource, TDest> where TDest : new() {
        public Expression<Func<TSource, TDest>> Foo() => model => new TDest();
        public Expression<Func<TSource, TDest>> Bar() => model => new TDest {};
    }
