    /// <summary>
    /// An ugly hack for when you don't want to create a new wrapper class that inherits from and implements two other interfaces
    /// </summary>
    /// <typeparam name="TOne"></typeparam>
    /// <typeparam name="TTwo"></typeparam>
    public sealed class MultiType<TOne, TTwo>
    {
        /// <summary>
        /// The contained item
        /// </summary>
        private readonly object _containedObject;
    
        /// <summary>
        /// The contained item as a TOne
        /// </summary>
        public TOne AsOne => (TOne)_containedObject;
    
        /// <summary>
        /// The contained item as a TTwo
        /// </summary>
        public TTwo AsTwo => (TTwo)_containedObject;
    
        /// <summary>
        /// Creates a new MultiType that exposes the given item as two different classes
        /// </summary>
        /// <param name="containedObject"></param>
        private MultiType(object containedObject)
        {
            if (containedObject is TOne && containedObject is TTwo)
                _containedObject = containedObject;
            else
                throw new Exception("The given object must be both a TOne and a TTwo");
        }
    
        /// <summary>
        /// Creates a new MultiType that exposes the given thing as both a TOne and a TTwo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="thing"></param>
        /// <returns></returns>
        public static MultiType<TOne, TTwo> Create<T>(T thing)
            where T : TOne, TTwo
            => new MultiType<TOne, TTwo>(thing);
    }
