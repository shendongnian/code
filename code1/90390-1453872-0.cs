    using System;
    using System.Runtime.Remoting;
    namespace TestStackOverflow
    {
        class Program
        {
            class StackOver : MarshalByRefObject
            {
                public void Run()
                {
                    Run();
                }
            }
            static void Main(string[] args)
            {
            AppDomain domain = AppDomain.CreateDomain("new");
            ObjectHandle handle = domain.CreateInstance(typeof (StackOver).Assembly.FullName, typeof (StackOver).FullName);
            if (handle != null)
            {
                StackOver stack = (StackOver) handle.Unwrap();
                stack.Run();
            }
        }
    }
    }
