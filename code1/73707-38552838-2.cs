    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    /// <summary>
    /// Manage an array that holds sensitive information.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the array. Limited to built in types.
    /// </typeparam>
    public sealed class SecureArray<T> : SecureArray
    {
        private readonly T[] buf;
        /// <summary>
        /// Initialize a new instance of the <see cref="SecureArray{T}"/> class.
        /// </summary>
        /// <param name="size">
        /// The number of elements in the secure array.
        /// </param>
        /// <param name="noswap">
        /// Set to true to do a Win32 VirtualLock on the allocated buffer to
        /// keep it from swapping to disk.
        /// </param>
        public SecureArray(int size, bool noswap = true)
        {
            this.buf = new T[size];
            this.Init(this.buf, ElementSize(this.buf) * size, noswap);
        }
        /// <summary>
        /// Gets the secure array.
        /// </summary>
        public T[] Buffer => this.buf;
        /// <summary>
        /// Gets or sets elements in the secure array.
        /// </summary>
        /// <param name="i">
        /// The index of the element.
        /// </param>
        /// <returns>
        /// The element.
        /// </returns>
        public T this[int i]
        {
            get
            {
                return this.buf[i];
            }
            set
            {
                this.buf[i] = value;
            }
        }
    }
