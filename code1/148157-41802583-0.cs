    namespace ConsoleApp1
    {
    class Program
    {
        static void Main(string[] args)
        {
            SomeImplementation s = new SomeImplementation();
            s.DoSomething(new SomeActualData());
            s.DoSomething(new SomeOtherData());
            Console.ReadLine();
        }
    }
    interface ISomeData { }
    class SomeActualData : ISomeData { }
    class SomeOtherData : ISomeData { }
    interface ISomeInterface
    {
        void DoSomething(ISomeData data);
    }
    class SomeImplementation : ISomeInterface
    {
        public void DoSomething(ISomeData data)
        {
            dynamic specificData = data;
            HandleThis(specificData);
        }
        private void HandleThis(SomeActualData data)
        {
            Console.WriteLine("this is SomeActualData");
        }
        private void HandleThis(SomeOtherData data)
        {
            Console.WriteLine("this is SomeOtherData");
        }
    }
    }
