    public class WeakReference<T>
        where T : class
    {
        private WeakReference inner;
        /// <summary>
        /// Initializes a new instance of the System.WeakReference class, referencing 
        /// the specified object.
        /// </summary>
        /// <param name="target">The object to track or null.</param>
        public WeakReference(T target)
            : this(target, false)
        { }
        /// <summary>
        /// Initializes a new instance of the System.WeakReference class, referencing
        /// the specified object and using the specified resurrection tracking.
        /// </summary>
        /// <param name="target">An object to track.</param>
        /// <param name="trackResurrection">Indicates when to stop tracking the object. 
        /// If true, the object is tracked after finalization; if false, the object is 
        /// only tracked until finalization.</param>
        public WeakReference(T target, bool trackResurrection)
        {
            if (target == null) throw new ArgumentNullException("target");
            this.inner = new WeakReference((object)target, trackResurrection);
        }
        /// <summary>
        /// Gets or sets the object (the target) referenced by the current 
        /// System.WeakReference object.
        /// </summary>
        public T Target { get { return (T)this.inner.Target; } set { this.inner.Target = value; } }
        /// <summary>
        /// Gets an indication whether the object referenced by the current 
        /// System.WeakReference object has been garbage collected.
        /// </summary>
        public bool IsAlive { get { return this.inner.IsAlive; } }
        /// <summary>  
        /// Casts an object of the type T to a weak reference  
        /// of T.  
        /// </summary>  
        public static implicit operator WeakReference<T>(T target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            return new WeakReference<T>(target);
        }
        /// <summary>  
        /// Casts a weak reference to an object of the type the  
        /// reference represents.  
        /// </summary>  
        public static implicit operator T(WeakReference<T> reference)
        {
            if (reference != null)
            {
                return reference.Target;
            }
            else
            {
                return null;
            }
        }
    }
}
