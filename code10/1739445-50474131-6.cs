        /// <summary>
        /// Retrieves a shared <see cref="ArrayPool{T}"/> instance.
        /// </summary>
        /// <remarks>
        /// The shared pool provides a default implementation of <see cref="ArrayPool{T}"/>
        /// that's intended for general applicability.  It maintains arrays of multiple sizes, and 
        /// may hand back a larger array than was actually requested, but will never hand back a smaller 
        /// array than was requested. Renting a buffer from it with <see cref="Rent"/> will result in an 
        /// existing buffer being taken from the pool if an appropriate buffer is available or in a new 
        /// buffer being allocated if one is not available.
        /// </remarks>
        public static ArrayPool<T> Shared
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return Volatile.Read(ref s_sharedInstance) ?? EnsureSharedCreated(); }
        }
