    using System;
    using System.Reflection;
    static class Program { // formatted for space
        static void Main() {
            // do this in a loop to see benefit...
            int i = Test<int>.Parse("123");
            float f = Test<float>.Parse("123.45");
        }
    }
    static class Test<T> {
        public static T Parse(string text) { return parse(text); }
        static readonly Func<string, T> parse;
        static Test() {
            try {
                MethodInfo method = typeof(T).GetMethod("Parse",
                    BindingFlags.Public | BindingFlags.Static,
                    null, new Type[] { typeof(string) }, null);
                parse = (Func<string, T>) Delegate.CreateDelegate(
                    typeof(Func<string, T>), method);
            } catch (Exception ex) {
                string msg = ex.Message;
                parse = delegate { throw new NotSupportedException(msg); };
            }
        }
    }
