    public interface ITest1 { string Get(); }
    public interface ITest2 { string Get(); }
    public class MyTest : ITest1, ITest2
    {
        string ITest1.Get() { return "hello"; }
        string ITest2.Get() { return "world"; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mytest = new MyTest();
            // note that mytest.Get() does not exist when interfaces are explicit
            var v1 = ((ITest1)mytest).Get(); //hello
            var v2 = ((ITest2)mytest).Get(); //world
        }
    }
