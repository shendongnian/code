    using System;
    
    namespace Frank
    {
        public class WeakReference<T> where T : class
        {
            private WeakReference inner;
    
            public WeakReference(T target)
                : this(target, false)
            { }
    
            public WeakReference(T target, bool trackResurrection)
            {
                if(target == null) throw new ArgumentNullException("target");
                this.inner = new WeakReference((object)target, trackResurrection);
            }
    
            public T Target
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
            public bool IsAlive {
                get {
                     return this.inner.IsAlive;
                }
            }
        }
    }
