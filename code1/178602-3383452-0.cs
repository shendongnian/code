    using System;
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                ParamsTest(new { A = "a", B = "b"});
            }
            public static void ParamsTest(object o)
            {
                if (o == null)
                {
                    throw new ArgumentNullException();
                }
                var t = o.GetType();
                var aValue = t.GetProperty("A").GetValue(o, null);
                var bValue = t.GetProperty("B").GetValue(o, null);
            }
        }
    }
