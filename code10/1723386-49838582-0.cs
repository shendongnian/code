    using System;
    
    class Program
    {
        enum MyEnum
        {
            FirstValue,
            SecondValue,
            ThirdValue,
            FourthValue
        }
    
        public static void doStuff(string constValue)
        {
            var parsedValue = Enum.Parse(typeof(MyEnum), constValue);
    
            Console.WriteLine($"Type: { parsedValue.GetType() }, value: { parsedValue }");
        }
    
        static void Main(string[] args)
        {
            doStuff("FirstValue");      // Runs 
            doStuff("FirstValuesss");   // Throws ArgumentException
        }
    }
