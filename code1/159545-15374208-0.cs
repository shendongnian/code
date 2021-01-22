    namespace System
    {
        public class ok : ok<string> { }
        public class ok<T> {
            T s;
            public static implicit operator ok<T>(T s) { return new ok<T> { s = s }; }
            public static implicit operator T(ok<T> _) { return _.s; }
            public static bool operator true(ok<T> _) { return _.s != null; }
            public static bool operator false(ok<T> _) { return _.s == null; }
            public static ok<T> operator &(ok<T> x, ok<T> y) { return y; }
        }    
    }
