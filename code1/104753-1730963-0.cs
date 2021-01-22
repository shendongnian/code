        public static void Main()
        {
            var b = new FooBar();
            b.DoWork += b_OnWorkCompleted;
            b.DoWork += c_OnWorkCompleted;
            Console.WriteLine(b.IsAttached("b_OnWorkCompleted"));
            Console.WriteLine(b.IsAttached("c_OnWorkCompleted"));
            Console.WriteLine(b.IsAttached("FooBar"));
            b.InvokeOnWorkCompleted("Test");
            Console.ReadLine();
        }
        private static void c_OnWorkCompleted(string s)
        {
            Console.WriteLine("S:" + s);
        }
        static void b_OnWorkCompleted(string s)
        {
            Console.WriteLine(s);
        }
    }
    public class FooBar
    {
        public delegate void SomeWork(string s);
        public event SomeWork DoWork;
        public bool IsAttached(string methodName)
        {
            SomeWork completed = DoWork;
            return completed.GetInvocationList().Any(m => m.Method.Name == methodName);
        }
        public void InvokeOnWorkCompleted(string s)
        {
            SomeWork completed = DoWork;
            if (completed != null) completed(s);
        }
    }
