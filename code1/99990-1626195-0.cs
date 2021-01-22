    using System;
    class Program
    {
        public delegate void TestMethod();
        public class Test
        {
            public void MyMethod()
            {
                Console.WriteLine("Test");
            }
        }
        static void Main(string[] args)
        {
            Test t = new Test();
            Type test = t.GetType();
            var reflectedMethod = test.GetMethod("MyMethod");
            TestMethod method = (TestMethod)Delegate.CreateDelegate(typeof(TestMethod), t, reflectedMethod);
            method();
        }
    }
