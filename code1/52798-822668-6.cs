    class Base : IDisposable
    {
        public void Dispose()
        {
            // Base Dispose() logic
        }
    }
    class Child : Base, IDisposable
    {
        // public here ensures that Child.Dispose() doesn't resolve to the public Base.Dispose()
        public new void Dispose()
        {
            try
            {
                // Child Dispose() logic
            }
            finally
            {
                // ensure that the Base.Dispose() is called
                base.Dispose();
            }
        }
        void IDisposable.Dispose()
        {
            // Redirect IDisposable.Dispose() to Child.Dispose()
            Dispose();
        }
    }
