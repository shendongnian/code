    public interface ITest1 { string Get(); }
    public interface ITest2 { string Get(); }
    // new is just to get rid of a compiler warning
    public interface ITest3 : ITest1, ITest2 { new string Get(); }
    public class MyTest : ITest1, ITest2
    {
        public string Get() { return "local"; }
        string ITest1.Get() { return "hello"; }
        string ITest2.Get() { return "world"; }
        string ITest3.Get() { return "hi"; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mytest = new MyTest();
            // note that if mytest.Get() does not exist if all of the 
            // interfaces are explicit
            var v0 = mytest.Get(); //local
            var v1 = ((ITest1)mytest).Get(); //hello
            var v2 = ((ITest2)mytest).Get(); //world
            var v3 = ((ITest3)mytest).Get(); //hi
        }
    }
