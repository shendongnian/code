    public class Example
    {
        public delegate void DoStuffDelecate();
        public DoStuffDelecate DoStuff;
        public delegate void DoStuffWithDelecate(int n);
        public DoStuffWithDelecate DoStuffWithParameter;
        public delegate int DoStuffWithReturnDelecate();
        public DoStuffWithReturnDelecate DoStuffWithReturnValue;
    }
    class Program
    {
        static int MethodWithReturnValue()
        {
            return 99;
        }
        static void MethodForDelecate()
        {
            Console.WriteLine("Did Stuff");
        }
        static void MethodForDelecate(int n)
        {
            Console.WriteLine("Did Stuff with parameter " + n);
        }
        static void Main(string[] args)
        {
            var x = new Example();
            x.DoStuff = MethodForDelecate;
            x.DoStuffWithParameter = MethodForDelecate;
            x.DoStuffWithReturnValue = MethodWithReturnValue;
            x.DoStuff();
            x.DoStuffWithParameter(10);
            int value = x.DoStuffWithReturnValue();
            Console.WriteLine("Return value " + value);
            Console.ReadLine();
        }
    }
