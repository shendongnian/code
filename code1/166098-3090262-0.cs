    class MyClass {
    
        public event EventHandler SomethingHappened;
    
        protected virtual void OnSomethingHappened(EventArgs e) {
            EventHandler handler = SomethingHappened;
            if (handler != null) {
                handler(this, e);
            }
        }
    
        public void DoSomething() {
            OnSomethingHappened(EventArgs.Empty);
        }
    
    }
