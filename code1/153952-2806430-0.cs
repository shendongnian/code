    public abstract class MyBase<T>
    {
        public abstract T GetSomething();
    }
    
    public class MyConcreteType : MyBase<int>
    {
        public override int GetSomething()
        {
             return 3;
        }
    }
