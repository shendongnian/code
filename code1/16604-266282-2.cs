    using System;
    using System.Reflection;
    
    public class Generic<T>
    {
        public Generic()
        {
            Console.WriteLine("T={0}", typeof(T));
        }
    }
    
    class Test
    {
        static void Main()
        {
            string typeName = "System.String";
            Type typeArgument = Type.GetType(typeName);
            
            Type genericClass = typeof(Generic<>);
            // MakeGenericType is badly named
            Type constructedClass = genericClass.MakeGenericType(typeArgument);
            
            object created = Activator.CreateInstance(constructedClass);
        }
    }
