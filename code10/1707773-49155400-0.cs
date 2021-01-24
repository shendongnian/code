    public interface IBaseWrapper<T> where T : IBaseWrapper<T>
    {
        void Baz();
    }
    public class BaseWrapper<T> : IBaseWrapper<T> where T : BaseWrapper<T>
    {
        private T _instance;
        public BaseWrapper(T instance)
        {
            _instance = instance;
        }
        public void Baz()
        {
            _instance.Baz();
        }
    }
