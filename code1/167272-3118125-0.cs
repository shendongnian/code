    public interface IAction1
    {
        int DoWork();
    }
    public interface IAction2
    {
        int DoWork();
    }
    public abstract class MyBase : IAction1
    {
        public int DoWork() { return 0; }
    }
    public class MyClass : MyBase, IAction2
    {
        public new int DoWork()
        {
            return ((IAction2)this).DoWork();
        }
        int IAction2.DoWork() { return 1; }
    }
    public class MyClass2 : MyClass { }
    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();
            var ret1 = ((IAction1)myClass).DoWork(); //0
            var ret2 = ((IAction2)myClass).DoWork(); //1
            var ret3 = ((MyBase)myClass).DoWork(); //0
            var ret4 = ((MyClass)myClass).DoWork(); //1
            var ret5 = ((MyClass2)myClass).DoWork(); //1
        }
    }
