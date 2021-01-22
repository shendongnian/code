    public interface ITest1
    {
        void Execute();
    }
    public interface ITest2
    {
        void Execute();
    }
    public class MyTest : ITest1, ITest2
    {
        void ITest1.Execute()
        {
            Console.WriteLine("hello");
        }
        void ITest2.Execute()
        {
            Console.WriteLine("world");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mytest = new MyTest();
            ((ITest1)mytest).Execute(); //hello
            ((ITest2)mytest).Execute(); //world
        }
    }
