    public interface IProcessor
    {
        void Process(object instance);
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
        void IProcessor.Process(object instance)
        {
            Process((int)instance);
        }
    }
