    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading big file...");
    
            FileStream fileStream = File.OpenRead("c:\\temp\\bigfile.xml");
            ProgressStreamWrapper progressStreamWrapper = new ProgressStreamWrapper(fileStream);
            progressStreamWrapper.PositionChanged += (o, ea) => Console.WriteLine((double) progressStreamWrapper.Position / progressStreamWrapper.Length * 100 + "% complete");
            XmlReader xmlReader = XmlReader.Create(progressStreamWrapper);
            
            while (xmlReader.Read())
            {
                //read the xml document
            }
    
            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
    
    
    public class ProgressStreamWrapper : Stream, IDisposable
    {
        public ProgressStreamWrapper(Stream innerStream)
        {
            InnerStream = innerStream;
        }
    
        public Stream InnerStream { get; private set; }
    
        public override void Close()
        {
            InnerStream.Close();
        }
    
        void IDisposable.Dispose()
        {
            base.Dispose();
            InnerStream.Dispose();
        }
    
        public override void Flush()
        {
            InnerStream.Flush();
        }
    
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return InnerStream.BeginRead(buffer, offset, count, callback, state);
        }
    
        public override int EndRead(IAsyncResult asyncResult)
        {
            int endRead = InnerStream.EndRead(asyncResult);
            OnPositionChanged();
            return endRead;
        }
    
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return InnerStream.BeginWrite(buffer, offset, count, callback, state);
        }
    
        public override void EndWrite(IAsyncResult asyncResult)
        {
            InnerStream.EndWrite(asyncResult);
            OnPositionChanged(); ;
        }
    
        public override long Seek(long offset, SeekOrigin origin)
        {
            long seek = InnerStream.Seek(offset, origin);
            OnPositionChanged();
            return seek;
        }
    
        public override void SetLength(long value)
        {
            InnerStream.SetLength(value);
        }
    
        public override int Read(byte[] buffer, int offset, int count)
        {
            int read = InnerStream.Read(buffer, offset, count);
            OnPositionChanged();
            return read;
        }
    
        public override int ReadByte()
        {
            int readByte = InnerStream.ReadByte();
            OnPositionChanged();
            return readByte;
        }
    
        public override void Write(byte[] buffer, int offset, int count)
        {
            InnerStream.Write(buffer, offset, count);
            OnPositionChanged();
        }
    
        public override void WriteByte(byte value)
        {
            InnerStream.WriteByte(value);
            OnPositionChanged();
        }
    
        public override bool CanRead
        {
            get { return InnerStream.CanRead; }
        }
    
        public override bool CanSeek
        {
            get { return InnerStream.CanSeek; }
        }
    
        public override bool CanTimeout
        {
            get { return InnerStream.CanTimeout; }
        }
    
        public override bool CanWrite
        {
            get { return InnerStream.CanWrite; }
        }
    
        public override long Length
        {
            get { return InnerStream.Length; }
        }
    
        public override long Position
        {
            get { return InnerStream.Position; }
            set
            {
                InnerStream.Position = value;
                OnPositionChanged();
            }
        }
    
        public event EventHandler PositionChanged;
    
        protected virtual void OnPositionChanged()
        {
            if (PositionChanged != null)
            {
                PositionChanged(this, EventArgs.Empty);
            }
        }
    
        public override int ReadTimeout
        {
            get { return InnerStream.ReadTimeout; }
            set { InnerStream.ReadTimeout = value; }
        }
    
        public override int WriteTimeout
        {
            get { return InnerStream.WriteTimeout; }
            set { InnerStream.WriteTimeout = value; }
        }
    }
