    class Program
    {
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass();
            Console.WriteLine(testClass.number);
            ChangeTest(testClass);
            Console.WriteLine(testClass.number);
            int i = 0;
            Console.WriteLine(i);
            ChangeInt(i);
            Console.WriteLine(i);
            Console.ReadKey();
        }
        public static void ChangeTest(TestClass t)
        {
            t.number++;
        }
        public static void ChangeInt(int i)
        {
            i++;
        }
    }
    
    public class TestClass
    {
        public int number = 0;
    }
