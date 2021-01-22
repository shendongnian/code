    class MyClass : IDisposable
    {
        private IDisposable disposableThing;
        public void DoStuffThatRequiresHavingAReferenceToDisposableThing() { ... }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        //etc... (see IDisposable on msdn)
} 
