    using System;
    using System.Reflection;
    
    static class Program
    {
        static void Main()
        {
            int i; float f; decimal d;
            if (Test.TryParse("123", out i)) {
                Console.WriteLine(i);
            }
            if (Test.TryParse("123.45", out f)) {
                Console.WriteLine(f);
            }
            if (Test.TryParse("123.4567", out d)) {
                Console.WriteLine(d);
            }
        }
    }
    public static class Test
    {
        public static bool TryParse<T>(string s, out T value) {
            return Cache<T>.TryParse(s, out value);
        }
        internal static class Cache<T> {
            public static bool TryParse(string s, out T value)
            {
                return func(s, out value);
            }    
            delegate bool TryPattern(string s, out T value);
            private static readonly TryPattern func;
            static Cache()
            {
                MethodInfo method = typeof(T).GetMethod(
                    "TryParse", new Type[] { typeof(string), typeof(T).MakeByRefType() });
                if (method == null) {
                    if (typeof(T) == typeof(string))
                        func = delegate(string x, out T y) { y = (T)(object)x; return true; };
                    else
                        func = delegate(string x, out T y) { y = default(T); return false; };
                } else {
                    func = (TryPattern) Delegate.CreateDelegate(typeof(TryPattern),method);
                }            
            }
        }
    }
