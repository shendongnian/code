    public interface ITest
    {
         void Test();
    }
    public interface ITest2
    {
         void Test();
    }
    public class Dual : ITest, ITest2
    {
        void ITest.Test()
        {
            Console.WriteLine("ITest.Test");
        }
        void ITest2.Test()
        {
            Console.WriteLine("ITest2.Test");
        }
        static void Main(string[] args)
        {
            var dual = new Dual();
            ITest test = dual;
            test.Test();
            ITest2 test2 = dual;
            test2.Test();
            Console.ReadLine();
        }
    }
}
