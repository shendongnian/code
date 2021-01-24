    interface IProcessable
    {
        void DoSomething(params object [] args);
    }
    public abstract class BaseClass : IProcessable
    {
        public abstract void DoSomething(params object[] args);
    }
    public class GenericDerived<T> : BaseClass where T : struct
    {
        public T data;
        public override void DoSomething(params object[] args)
        {
            data = (T)args.First();
        }
    }
