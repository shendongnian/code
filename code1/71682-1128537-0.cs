    class Program
    {
        static void Main(string[] args)
        {
            A parent;
            parent = new A(1, "Mike");
            parent.AddChild("Greg");
            parent.AddChild("Peter");
            parent.AddChild("Bobby");
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
               new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            SerializationSizer ss = new SerializationSizer();
            bf.Serialize(ss, parent);
            Console.WriteLine("Size of serialized object is {0}", ss.Length);
        }
    }
    [Serializable()]
    class A
    {
        int id;
        string name;
        List<B> children;
        public A(int id, string name)
        {
            this.id = id;
            this.name = name;
            children = new List<B>();
        }
        public B AddChild(string name)
        {
            B newItem = new B(this, name);
            children.Add(newItem);
            return newItem;
        }
    }
    [Serializable()]
    class B
    {
        A parent;
        string name;
        public B(A parent, string name)
        {
            this.parent = parent;
            this.name = name;
        }
    }
    class SerializationSizer : System.IO.Stream
    {
        private int totalSize;
        public override void Write(byte[] buffer, int offset, int count)
        {
            this.totalSize += count;
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override bool CanSeek
        {
            get { return false; }
        }
        public override bool CanWrite
        {
            get { return true; }
        }
        public override void Flush()
        {
            // Nothing to do
        }
        public override long Length
        {
            get { return totalSize; }
        }
        public override long Position
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
        public override long Seek(long offset, System.IO.SeekOrigin origin)
        {
            throw new NotImplementedException();
        }
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }
    }
