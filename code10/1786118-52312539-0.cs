    using System.IO;
    using System;
    
    public enum MyEnum
    {
        Foo,
        Bar
    }
    
    class Program
    {
        static void Main()
        {
            var value = MyEnum.Bar;
            var name = value.GetType().Name;
            Console.WriteLine($"The enum is: {name}.{value}");
        }
    }
