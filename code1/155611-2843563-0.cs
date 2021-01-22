    using System;
    using System.Collections.Generic;
    
    public class Base
    {
        public void DoSomething(IEnumerable<string> strings)
        {
            Console.WriteLine("Base");
        }
    }
    
    public class Derived : Base
    {
        public void DoSomething(IEnumerable<object> objects)
        {
            Console.WriteLine("Derived");
        }
    }
    
    public class Test
    {
        static void Main()
        {
            Derived d = new Derived();
            d.DoSomething(new List<string>());
        }
    }
