    public class BaseClass
    {
        public event EventHandler<MyArgs> SomeEvent;
    
        protected virtual void OnSomeEvent()
        {
            if(SomeEvent!= null)
                SomeEvent(this, new MyArgs(...) );
        }
    }
    
