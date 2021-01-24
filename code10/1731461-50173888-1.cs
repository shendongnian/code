    using System;
    
    class SomeClass
    {
        public int Value { get; }
        
        public SomeClass(int value) => Value = value;
        
        public static implicit operator SomeClass(int value) =>
            new SomeClass(value);
    }
    
    public class Program
    {
        static void Main()
        {
            SomeClass x = 123;
            Console.WriteLine(x.Value);
        }
    }
