    abstract class SomeBase<T> : IProcessor<T>
    {
        public void Process(T instance)
        {
            OnProcess(instance);
        }
        void IProcessor.Process(object instance)
        {
            Process((T)instance);
        }
        protected abstract void OnProcess(T instance);
    }
