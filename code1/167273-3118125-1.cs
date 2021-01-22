    public interface IAction1
    {
        int DoWork();
    }
    public interface IAction2
    {
        string DoWork();
    }
    public class MyBase : IAction1
    {
        public int DoWork() { return 0; }
    }
    public class MyClass : MyBase, IAction2
    {
        public new string DoWork() { return "Hi"; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();
            var ret0 = myClass.DoWork(); //Hi
            var ret1 = ((IAction1)myClass).DoWork(); //0
            var ret2 = ((IAction2)myClass).DoWork(); //Hi
            var ret3 = ((MyBase)myClass).DoWork(); //0
            var ret4 = ((MyClass)myClass).DoWork(); //Hi
        }
    }
