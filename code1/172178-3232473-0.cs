    using System;
    
    namespace Frank
    {
        public class WeakReference<T> where T : class
        {
            private WeakReference inner;
    
            public WeakReference(T target)
            {
                this.inner = new WeakReference((object)target);
            }
    
            public WeakReference(T target, bool trackResurrection)
            {
                this.inner = new WeakReference((object)target, trackResurrection);
            }
    
            public new T Target
            {
                get
                {
                    return (T)this.inner.Target;
                }
                set
                {
                    this.inner.Target = value;
                }
            }
        }
    }
