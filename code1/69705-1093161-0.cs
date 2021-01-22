    public interface IInterface
    {
        event EventHandler TestEvent;
    }
    
    public class Base : IInterface
    {
        public event EventHandler TestEvent;
    }
    
    public class Concrete : Base
    {
       //Nothing needed here
    }
