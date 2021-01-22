    using System;
    using System.Reflection;
    
    internal sealed class ABC
    {
        private ABC(string password)
        {
            Console.WriteLine("Constructor called");
        }
        
        public static ABC Create(string password)
        {
            return new ABC(password);
        }
    }
    
    public class Test
    {
        static void Main()
        {
            MethodInfo method = typeof(ABC).GetMethod("Create",
                BindingFlags.Static | BindingFlags.Public);
            
            ABC abc = (ABC) method.Invoke(null, new object[]{"test"});
        }
    }
