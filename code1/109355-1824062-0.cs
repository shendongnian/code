    public class MyClass
    {
        private readonly object lockObject = new object();
        public void MyMethod()
        {
            lock (lockObject)
            {
                // Do stuff
            }
        }
        public void AnotherMethod()
        {
            lock (lockObject)
            {
                // Do stuff
            }
        }
    }
