    using System;
    [AttributeUsage(validOn : AttributeTargets.Class)]
    public class MyAttribute : Attribute
    {
        public MyAttribute(int x)
        {
            Console.WriteLine("MyAttribute created with {0}.", x);
            Value = x;
        }
        public int Value { get; private set; }    
    }
