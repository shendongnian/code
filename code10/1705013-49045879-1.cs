    public interface IOtherInterface
    {
    }
    public interface IAnInterface<T> where T : IOtherInterface
    {
        void DoSomething(T parameter);
    }
    public class ThisWontWork
    {
    }
    var other = new OtherInterface();
    var an = new AnInterface();
    an.DoSomething(other); // this works
    var wontWork = new ThisWontWork();
    an.DoSomething(wontWork);  // will not build
