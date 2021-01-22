    public abstract class Base
    {
        protected abstract void InternalFoo();
        protected abstract void InternalBar();
    
        public void Foo()
        {
            try { this.InternalFoo(); }
            catch { /* ... */ }
        }
    
        public void Bar()
        {
            try { this.InternalBar(); }
            catch { /* ... */ }
        }
    }
