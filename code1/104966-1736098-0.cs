    using System;
    using System.Reflection;
    class Test
    {
        public string Foo(int i)
        {
            return i.ToString();
        }
        static void Main()
        {
            MethodInfo method = typeof(Test).GetMethod("Foo");
            Func<Test, int, string> func = (Func<Test, int, string>)
                Delegate.CreateDelegate(typeof(Func<Test, int, string>), null, method);
            Test t = new Test();
            string s = func(t, 123);
    
        }
    }
