    using System.IO;
    using System;
    class Program
    {
        public class M<A>
        {
            public A val;
            public string messages;
        }
        
        public static M<B> feed<A, B>(Func<A, M<B>> f, M<A> x)
        {
            M<B> m = f(x.val);
            m.messages = x.messages + m.messages;
            return m;
        }
        public static M<A> wrap<A>(A x)
        {
            M<A> m = new M<A>();
            m.val = x;
            m.messages = "";
            return m;
        }
        public class T {};
        public class U {};
        public class V {};
        public static M<U> g(V x)
        {
            M<U> m = new M<U>();
            m.messages = "called g.\n";
            return m;
        }
        public static M<T> f(U x)
        {
            M<T> m = new M<T>();
            m.messages = "called f.\n";
            return m;
        }
        
        static void Main()
        {
            V x = new V();
            M<T> m = feed<U, T>(f, feed(g, wrap<V>(x)));
            Console.Write(m.messages);
        }
    }
