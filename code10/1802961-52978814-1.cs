    using System;
    using System.IO;
    using System.Threading.Tasks;
    /// <summary>
    /// Represents a filestream with cache.
    /// </summary>
    public class CachableFileStream : FileStream
    {
        private Cache<byte> cache;
        private int preloadSize;
        private int reloadSize;
        /// <summary>
        /// Gets or sets the amount of bytes to be preloaded.
        /// </summary>
        public int PreloadSize
        {
            get
            {
                return this.preloadSize;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "The specified preload size must not be smaller than or equal to zero.");
                this.preloadSize = value;
            }
        }
        /// <summary>
        /// Gets or sets the amount of bytes to be reloaded.
        /// </summary>
        public int ReloadSize
        {
            get
            {
                return this.reloadSize;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "The specified reload size must not be smaller than or equal to zero.");
                this.reloadSize = value;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CachableFileStream"/> class with the specified path and creation mode.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current CachableFileStream object will encapsulate</param>
        /// <param name="mode">A constant that determines how to open or create the file.</param>
        /// <exception cref="System.ArgumentException">
        /// Path is an empty string (""), contains only white space, or contains one or more invalid characters.
        /// -or- path refers to a non-file device, such as "con:", "com1:", "lpt1:", etc. in an NTFS environment.
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Path refers to a non-file device, such as "con:", "com1:", "lpt1:", etc. in a non-NTFS environment.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Path is null.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// The caller does not have the required permission.
        /// </exception>
        /// <exception cref="System.IO.FileNotFoundException">
        /// The file cannot be found, such as when mode is FileMode.Truncate or FileMode.Open, and the file specified by path does not exist.
        /// The file must already exist in these modes.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error, such as specifying FileMode.CreateNew when the file specified by path already exists, occurred.-or-The stream has been closed.
        /// </exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">
        /// The specified path is invalid, such as being on an unmapped drive.
        /// </exception>
        /// <exception cref="System.IO.PathTooLongException">
        /// The specified path, file name, or both exceed the system-defined maximum length.
        /// For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Mode contains an invalid value
        /// </exception>
        public CachableFileStream(string path, FileMode mode) : base(path, mode)
        {
            this.cache = new Cache<byte>();
            this.cache.CacheIsRunningLow += CacheIsRunningLow;
        }
        /// <summary>
        /// Reads a block of bytes from the stream and writes the data in a given buffer.
        /// </summary>
        /// <param name="array">
        /// When this method returns, contains the specified byte array with the values between
        /// offset and (offset + count - 1) replaced by the bytes read from the current source.
        /// </param>
        /// <param name="offset">The byte offset in array at which the read bytes will be placed.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>
        /// The total number of bytes read into the buffer. This might be less than the number
        /// of bytes requested if that number of bytes are not currently available, or zero
        /// if the end of the stream is reached.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Array is null.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Offset or count is negative.
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// The stream does not support reading.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        /// An I/O error occurred.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Offset and count describe an invalid range in array.
        /// </exception>
        /// <exception cref="System.ObjectDisposedException">
        /// Methods were called after the stream was closed.
        /// </exception>
        public override int Read(byte[] array, int offset, int count)
        {
            int readBytesFromCache;
            for (readBytesFromCache = 0; readBytesFromCache < count; readBytesFromCache++)
            {
                if (this.cache.Size == 0)
                    break;
                array[offset + readBytesFromCache] = this.cache.Read();
            }
            if (readBytesFromCache < count)
                readBytesFromCache += base.Read(array, offset + readBytesFromCache, count - readBytesFromCache);
            return readBytesFromCache;
        }
        /// <summary>
        /// Preload data into the cache.
        /// </summary>
        public void Preload()
        {
            this.LoadBytesFromStreamIntoCache(this.PreloadSize);
        }
        /// <summary>
        /// Reload data into the cache.
        /// </summary>
        public void Reload()
        {
            this.LoadBytesFromStreamIntoCache(this.ReloadSize);
        }
        /// <summary>
        /// Loads bytes from the stream into the cache.
        /// </summary>
        /// <param name="count">The number of bytes to read.</param>
        private void LoadBytesFromStreamIntoCache(int count)
        {
            byte[] buffer = new byte[count];
            int readBytes = base.Read(buffer, 0, buffer.Length);
            this.cache.AddRange(buffer, 0, readBytes);
        }
        /// <summary>
        /// Represents the event handler for the CacheIsRunningLow event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void CacheIsRunningLow(object sender, EventArgs e)
        {
            this.cache.WarnIfRunningLow = false;
            new Task(() =>
            {
                Reload();
                this.cache.WarnIfRunningLow = true;
            }).Start();
        }
    }
