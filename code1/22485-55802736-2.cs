.NetCore 2.1
namespace ConsoleApp1
{
    class Program
    {
        public const int Cycles = 100000000;
        public static int Cycles2 = 100000000;
        public static QSData TestObject = new QSData();
        public static Type TestObjectType;
        static void Main(string[] args)
        {
            TestObjectType = TestObject.GetType();
            Console.WriteLine("Repeated cycles for each test : " + Cycles.ToString());
            var test1 = TestGetType();
            Console.WriteLine("Object.GetType : " + test1.ToString());
            var test2 = TestTypeOf();
            Console.WriteLine("TypeOf(Class)  : " + test2.ToString());
            var test3 = TestVar();
            Console.WriteLine("Type var       : " + test3.ToString());
            var test4 = TestEmptyLoop();
            Console.WriteLine("Empty Loop     : " + test4.ToString());
            Console.WriteLine("\r\nClean overview:");
            Console.WriteLine("Object.GetType : " + (test1 - test4).ToString());
            Console.WriteLine("TypeOf(Class)  : " + (test2 - test4).ToString());
            Console.WriteLine("Type var       : " + (test3 - test4).ToString());
            Console.WriteLine("\n\rPush a button to exit");
            String input = Console.ReadLine();
        }
        static long TestGetType()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < Cycles; i++)
            {
                Type aType = TestObject.GetType();
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        static long TestTypeOf()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < Cycles; i++)
            {
                Type aType = typeof(QSData);
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        static long TestVar()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < Cycles; i++)
            {
                Type aType = TestObjectType;
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        static long TestEmptyLoop()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < Cycles; i++)
            {
                Type aType;
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
