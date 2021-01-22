    using System;
    
    class Person
    {
        public string Name { get; set; }
    }
    
    class Test
    {
        static void Main(){} // Just make it easier to compile
        
        static void Foo(Person p)
        {
            string tmp = p.Name;
            Bar(ref tmp);
        }
        
        static void Bar(ref string x)
        {
        }
    }
