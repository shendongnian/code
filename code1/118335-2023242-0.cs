    using System;
    using System.Reflection;
    
    internal sealed class ABC
    {
        private ABC(string password)
        {
            Console.WriteLine("Constructor called");
        }
    }
    
    public class Test
    {
        static void Main()
        {
            ConstructorInfo ctor = typeof(ABC).GetConstructors
                (BindingFlags.Instance | BindingFlags.NonPublic)[0];
            
            ABC abc = (ABC) ctor.Invoke(new object[] { "test" });
        }
    }
