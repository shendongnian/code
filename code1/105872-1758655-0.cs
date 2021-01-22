    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // exception is reported at method A, even though it is thrown by method B
                MethodA();
            }
    
            private static void MethodA()
            {
                MethodB();
            }
    
            private static void MethodB()
            {
                throw new MyException();
            }
        }
    
        public class MyException : Exception
        {
            private readonly string _stackTrace;
    
            public MyException()
            {
                // skip the top two frames, which would be this constructor and whoever called us
                _stackTrace = new StackTrace(2).ToString();
            }
    
            public override string StackTrace
            {
                get { return _stackTrace; }
            }
        }
    }
