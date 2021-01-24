    public interface ITestInterface<out T>
    {
         T GetValue();
    }
    public class Test<T> : ITestInterface<T>
    {
        public T Value { get; set; }
        public T GetValue()
        {
            throw new NotImplementedException();
        }
        public void SetValue(T para)
        {
            Value = para;
        }
    }
