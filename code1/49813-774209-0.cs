    public class A
    {
        // ...
        public event EventHandler SomethingHappened;
    }
    public class B
    {
        private void DoSomething() { /* ... */ } // instance method
        private void Attach(A obj)
        {
           obj.SomethingHappened += DoSomething();
        }
    }
