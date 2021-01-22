    class Program
    {
        static void Main(string[] args)
        {
            var test = new DerivedTest();
            object o = test.Func();
            Console.WriteLine(o == null);
            Console.ReadLine();
        }
    }
    class BaseTest
    {
        public BaseTest(Func<object> func)
        {
            this.Func = func;
        }
        public Func<object> Func { get; private set; }
    }
    class DerivedTest : BaseTest
    {
        public DerivedTest() : base(() => this)
        {
        }
    }
