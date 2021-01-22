    public delegate void SomeEventHandler(object sender, SomeType value)
    public class SomeType
    {
    }
    public interface ISomething
    {
        public event SomeEventHandler SomeEvent;
    }
