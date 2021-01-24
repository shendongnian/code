    class Program
    {
        private static Action Call = OnlyCalledOnce;
        public static void Main(string[] args)
        {
            Call();
            Call();
            Call();
            Console.ReadKey();
        }
        static void DoesNothing()
        {
            Console.WriteLine("DoesNothing");
        }
        static void OnlyCalledOnce()
        {
            Console.WriteLine("OnlyCalledOnce");
            Call = DoesNothing;
        }
    }
