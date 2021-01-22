    public static class Converter
    {
        public static T ReturnAs<T>(T item)
        {
            return item;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var item = new MyType();
            // Option 1 - Implicit cast. Compile time checked but takes two lines.
            IMyType item2 = item;
            System.Console.WriteLine(item2.SayHello());
            // Option 2 - One line but risks an InvalidCastException at runtime if MyType changes.
            System.Console.WriteLine(((IMyType)item).SayHello());
            // Option 3 - One line but risks a NullReferenceException at runtime if MyType changes.
            System.Console.WriteLine((item as IMyType).SayHello());
            // Option 4 - compile time one liner
            Converter.ReturnAs<IMyType>(item).SayHello();
        }
    }
