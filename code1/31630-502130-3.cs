    public interface IProcessor
    {
        void Process(object instance);
        Type InstanceType {get;}
    }
    public interface IProcessor<T> : IProcessor
    {
        void Process(T instance);
    }
    class SomeClass: IProcessor<int>
    {
        public void Process(int instance)
        {
            throw new NotImplementedException();
        }
        Type IProcessor.InstanceType {get {return typeof(int);}}
        void IProcessor.Process(object instance)
        {
            Process((int)instance);
        }
    }
