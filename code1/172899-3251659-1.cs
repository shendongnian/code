    using System;
    namespace Scratch
    {
        public class Program
        {
            private static void Main()
            {
                new Test2().DoSomething2("hello");
                new Test4().DoSomething4("world");
            }
        }
        public class Test2
        {
            public void DoSomething2(string s)
            {
                new Test3().DoSomething3(s);
            }
        }
        public class Test3
        {
            public void DoSomething3(string s)
            {
                int i;
                Console.WriteLine(int.TryParse(s, out i));
            }
        }
        public class Test4
        {
            public void DoSomething4(string s)
            {
                int i;
                Console.WriteLine(int.TryParse(s, out i));
            }
        }
    }
