    namespace UnityTest
    {
        using System;
        using Unity;
    
        class Program
        {
            public class TestClass
            {
                public static int Version = 0;
    
                public TestClass()
                {
                    Version++;
                    Console.WriteLine(Version);
                }
            }
    
            static void Main(string[] args)
            {
                var container = new UnityContainer();
    
                var obj = new TestClass();
    
                container.RegisterInstance(obj, new TransientLifetimeManager());
    
                container.Resolve<TestClass>();
                container.Resolve<TestClass>();
                container.Resolve<TestClass>();
            }
        }
    }
