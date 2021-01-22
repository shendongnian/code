    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    [assembly: InternalsVisibleTo("System.Reflection")]
    
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
    
        unsafe class TestClass
        {
            internal TestClass(Int32 id)
            {
                Console.WriteLine("Test class instantiated with id: " + id);
            }
        }
    }
