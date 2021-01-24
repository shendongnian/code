    using System;
    using System.Linq;
    
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    sealed class StatusAttribute : Attribute
    {
        public StatusAttribute(string name) { Name = name; }
        public string Name { get; }
    }
    [Status("A Status")]
    public class A
    { /* ... */  }
    
    [Status("B Status")]
    public class B
    { /* ... */  }
    
    [Status("C Status")]
    public class C
    { /* ... */  }
    
    static class P
    {
        static void Main()
        {
            var attrib = typeof(StatusAttribute);
            var pairs = from s in AppDomain.CurrentDomain.GetAssemblies()
                        from p in s.GetTypes()
                        where p.IsDefined(attrib, false)
                        select new
                        {
                            Type = p,
                            Status = ((StatusAttribute)Attribute.GetCustomAttribute(
                                      p, attrib)).Name
                        };
    
            foreach(var pair in pairs)
            {
                Console.WriteLine($"{pair.Type.Name}: {pair.Status}");
            }
        }
    
    }
