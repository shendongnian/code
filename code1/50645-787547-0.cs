    public class A
    {
       public void DoSomething();
    }
    public interface IDoSomething
    {
       void DoSomething();
    }
    public class B : A, IDoSomething
    { }
