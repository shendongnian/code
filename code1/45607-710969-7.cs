    /// <summary>
    /// Generic implementation of <see cref="EventArgs"/> that allows for a data element to be passed.
    /// </summary>
    /// <typeparam name="T">The type of data to contain.</typeparam>
    [DebuggerDisplay("{Data}")]
    public class DataEventArgs<T> : EventArgs
    {
        private T _data;
        /// <summary>
        /// Constructs a <see cref="DataEventArgs{T}"/>.
        /// </summary>
        /// <param name="data">The data to contain in the <see cref="DataEventArgs{T}"/></param>
        [DebuggerHidden]
        public DataEventArgs(T data)
        {
            _data = data;
        }
        /// <summary>
        /// Gets the data for this <see cref="DataEventArgs{T}"/>.
        /// </summary>
        public virtual T Data
        {
            [DebuggerHidden]
            get { return _data; }
            [DebuggerHidden]
            protected set { _data = value; }
        }
        [DebuggerHidden]
        public static implicit operator DataEventArgs<T>(T data)
        {
            return new DataEventArgs<T>(data);
        }
        [DebuggerHidden]
        public static implicit operator T(DataEventArgs<T> e)
        {
            return e.Data;
        }
    }
