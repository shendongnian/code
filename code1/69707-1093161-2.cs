    public class Base : IInterface
    {
        public event EventHandler TestEvent;
        protected virtual void OnTestEvent()
        {
            if (TestEvent != null)
           {
               TextEvent(this, EventArgs.Empty);
           }
        }
    }
    
    public class Concrete : Base
    {
       public void SomethingHappened()
       {
           OnTestEvent();
       }
    }
