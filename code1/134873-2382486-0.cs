    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        public class MyException : Exception
        {
            public MyException(string message) : base(message)
            {}
    
            //...
        }
    
        public class MyClass
        {
            private Exception exception;
    
            public MyClass(Exception e)
            {
                this.exception = e;
            }
    
            public void ThrowMyException()
            {
                throw exception;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                MyException myExceptionInstance = new MyException("A custom message");
                MyClass myClassInstance = new MyClass(myExceptionInstance);
    
    
                myClassInstance.ThrowMyException();
    
            }
        }
    }
