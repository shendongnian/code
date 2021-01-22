    class Program
    {
        static void Main(string[] args)
        {
            TestStruct test = new TestStruct();
            test.Bar = 100;
            test.Foo = 200;
            using (MemoryStream ms = new MemoryStream())
            {
                using (ObjectStream os = new ObjectStream(ms, false))
                {
                    os.Write(test);
                }
                ms.Seek(0, SeekOrigin.Begin);
                Console.WriteLine(BitConverter.ToString(ms.ToArray()));
                using (ObjectStream os = new ObjectStream(ms, false))
                {
                    TestStruct result = os.Read<TestStruct>();
                    Console.WriteLine(result.Bar);
                    Console.WriteLine(result.Foo);
                }
            }
            Console.ReadLine();
        }
    }
    struct TestStruct
    {
        public int Foo;
        public int Bar;
    }
    class ObjectStream : Stream
    {
        private Stream _backing;
        private bool _ownsStream = true;
        public ObjectStream(Stream source)
            :this(source, true)
        {
        }
        public ObjectStream(Stream source, bool ownsStream)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            _backing = source;
            _ownsStream = ownsStream;
        }
        public override bool CanRead
        {
            get
            {
                return _backing.CanRead;
            }
        }
        public override bool CanSeek
        {
            get
            {
                return _backing.CanSeek;
            }
        }
        public override bool CanWrite
        {
            get
            {
                return _backing.CanWrite;
            }
        }
        public override void Flush()
        {
            _backing.Flush();
        }
        public override long Length
        {
            get
            {
                return _backing.Length;
            }
        }
        public override long Position
        {
            get
            {
                return _backing.Position;
            }
            set
            {
                _backing.Position = value;
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return _backing.Read(buffer, offset, count);
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return _backing.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            _backing.SetLength(value);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            _backing.Write(buffer, offset, count);
        }
        /// <summary>
        /// Writes a value type to the stream.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        public int Write<T>(T value)
        {
            // An T[] would be a reference type, and alot easier to work with.
            T[] t = new T[1];
            t[0] = value;
            // Marshal.SizeOf will fail with types of unknown size. Try and see...
            int s = Marshal.SizeOf(typeof(T));
            // Create a temp array.
            byte[] target = new byte[s];
            // Grab a handle of the array we just created, pin it to avoid the gc
            // from moving it, then copy bytes from our stream into the address
            // of our array.
            GCHandle handle = GCHandle.Alloc(t, GCHandleType.Pinned);
            Marshal.Copy(handle.AddrOfPinnedObject(), target, 0, s); // ?? Problem
            // Write to the stream.
            Write(target, 0, s);
            return s;
        }
        /// <summary>
        /// Reads a value type from the stream.
        /// </summary>
        /// <typeparam name="T">The type to read.</typeparam>
        /// <returns>The data read from the stream.</returns>
        public T Read<T>()
        {
            // An T[] would be a reference type, and alot easier to work with.
            T[] t = new T[1];
            // Marshal.SizeOf will fail with types of unknown size. Try and see...
            int s = Marshal.SizeOf(typeof(T));
            byte[] target = new byte[s];
            // Make sure there is enough data.
            if (Read(target, 0, s) != s)
                throw new InvalidDataException("Not enough data.");
            // Grab a handle of the array we just created, pin it to avoid the gc
            // from moving it, then copy bytes from our stream into the address
            // of our array.
            GCHandle handle = GCHandle.Alloc(t, GCHandleType.Pinned);
            Marshal.Copy(target, 0, handle.AddrOfPinnedObject(), s);
            // Return the first (and only) element in the array.
            return t[0];
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && _ownsStream)
                _backing.Dispose();
            base.Dispose(disposing);
        }
    }
