    interface IBase
    {
        void Validate();
    }
    public abstract class BaseClass<T> : IBase
    {
        public void Validate()
        {
            Debug.Log("Validating");
        }
    }
    public class SubClassA : BaseClass<EventArgs>
    {
    }
    public class SubClassB : BaseClass<CancelEventArgs>
    {
    }
