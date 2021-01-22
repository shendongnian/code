    public class SomeType {
        public event EventHandler SomeEvent;
        protected virtual void OnSomeEvent() {
            EventHandler handler = SomeEvent;
            if(handler!=null) handler(this,EventArgs.Empty);
        }
        public void SomethingInteresting() {
            // blah
            OnSomeEvent(); // notify subscribers
            // blap
        }
        // ...
    }
