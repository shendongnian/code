    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    
    namespace ReflectionInternalTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Assembly asm = Assembly.GetExecutingAssembly();
    
                // Call normally
                new TestClass(1234);
    
                // Call with Reflection
                asm.CreateInstance("ReflectionInternalTest.TestClass", 
                    false, 
                    BindingFlags.Default | BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic, 
                    null, 
                    new Object[] {9876}, 
                    null, 
                    null);
    
                // Pause
                Console.ReadLine();
            }
        }
    
        class TestClass
        {
            internal TestClass(Int32 id)
            {
                Console.WriteLine("Test class instantiated with id: " + id);
            }
        }
    }
