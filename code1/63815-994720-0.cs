    using System.Reflection;
    
    public class TypeA
    {
        public virtual int Height { get; set; }
    }
    public class TypeB : TypeA
    {
        public new String Height { get; set; }
    }
    
    public class Class1 : TypeB
    {        
    }
    
    class Test
    {
        static void Main()
        {
            Type type = typeof(Class1);
            Console.WriteLine(GetLowestProperty(type, "Height").DeclaringType);
        }
        
        static PropertyInfo GetLowestProperty(Type type, string name)
        {
            while (type != null)
            {
                var property = type.GetProperty(name, BindingFlags.DeclaredOnly | 
                                                      BindingFlags.Public |
                                                      BindingFlags.Instance);
                if (property != null)
                {
                    return property;
                }
                type = type.BaseType;
            }
            return null;
        }
    }
