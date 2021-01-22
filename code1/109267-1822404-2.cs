    using System;
    using System.Linq.Expressions;
    class Foo {
        public Foo(int i) { /* ... */ }
    }
    static class Program {
        static T Create<T>(int i) {
            return CtorCache<T>.Create(i);
        }
        static class CtorCache<T> {
            static Func<int, T> ctor;
            public static T Create(int i) {
                if (ctor == null) ctor = CreateCtor();
                return ctor(i);
            }
            static Func<int, T> CreateCtor() {
                var param = Expression.Parameter(typeof(int), "i");
                var ci = typeof(T).GetConstructor(new[] {typeof(int)});
                if(ci == null) throw new InvalidOperationException("No such ctor");
                var body = Expression.New(ci, param);
                return Expression.Lambda<Func<int, T>>(body, param).Compile();
            }
        }
        static void Main() {
            Foo foo = Create<Foo>(123);
        }
    }
