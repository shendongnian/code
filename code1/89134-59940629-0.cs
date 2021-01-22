    public delegate void FireEvent(int num);
    public delegate void FireNiceEvent(object sender, SomeStandardArgs args);
    public class SomeStandardArgs : EventArgs
    {
        public SomeStandardArgs(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
    }
    class Program
    {
        public static event FireEvent OnFireEvent;
        public static event FireNiceEvent OnFireNiceEvent;
        static void Main(string[] args)
        {
            OnFireEvent += SomeSimpleEvent1;
            OnFireEvent += SomeSimpleEvent2;
            OnFireNiceEvent += SomeStandardEvent1;
            OnFireNiceEvent += SomeStandardEvent2;
            Console.WriteLine("Firing events.....");
            OnFireEvent?.Invoke(3);
            OnFireNiceEvent?.Invoke(null, new SomeStandardArgs("Fred"));
            //Console.WriteLine($"{HeightSensorTypes.Keyence_IL030}:{(int)HeightSensorTypes.Keyence_IL030}");
            Console.ReadLine();
        }
        private static void SomeSimpleEvent1(int num)
        {
            Console.WriteLine($"{nameof(SomeSimpleEvent1)}:{num}");
        }
        private static void SomeSimpleEvent2(int num)
        {
            Console.WriteLine($"{nameof(SomeSimpleEvent2)}:{num}");
        }
        private static void SomeStandardEvent1(object sender, SomeStandardArgs args)
        {
            
            Console.WriteLine($"{nameof(SomeStandardEvent1)}:{args.ID}");
        }
        private static void SomeStandardEvent2(object sender, SomeStandardArgs args)
        {
            Console.WriteLine($"{nameof(SomeStandardEvent2)}:{args.ID}");
        }
    }
