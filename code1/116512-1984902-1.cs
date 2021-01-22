    using System;
    using System.IO;
    using System.Xml;
    class ChattyStream : Stream
    {
        private Stream baseStream;
        public ChattyStream(Stream baseStream)
        {
            if (baseStream == null) throw new ArgumentNullException("baseStream");
            this.baseStream = baseStream;
            updateInterval = 1000;
        }
        public event EventHandler ProgressChanged;
        protected virtual void OnProgressChanged()
        {
            var handler = ProgressChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
        private void CheckDisposed()
        {
            if (baseStream == null) throw new ObjectDisposedException(GetType().Name);
        }
        protected Stream BaseStream
        {
            get { CheckDisposed(); return baseStream; }
        }
        int pos, updateInterval;
        public int UpdateInterval
        {
            get { return updateInterval; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("value");
                updateInterval = value;
            }
        }
        
        protected void Increment(int value)
        {
            if (value > 0)
            {
                pos += value;
                if (pos >= updateInterval)
                {
                    OnProgressChanged();
                    pos = pos % updateInterval;
                }
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int result = BaseStream.Read(buffer, offset, count);
            Increment(result);
            return result;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            BaseStream.Write(buffer, offset, count);
            Increment(count);
        }
        public override void SetLength(long value)
        {
            BaseStream.SetLength(value);
        }
        public override void Flush()
        {
            BaseStream.Flush();
        }
        public override long Position
        {
            get { return BaseStream.Position; }
            set { BaseStream.Position = value; }
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return BaseStream.Seek(offset, origin);
        }
        public override long Length
        {
            get { return BaseStream.Length; }
        }
        public override bool CanWrite
        {
            get { return BaseStream.CanWrite; }
        }
        public override bool CanRead
        {
            get { return BaseStream.CanRead; }
        }
        public override bool CanSeek
        {
            get { return BaseStream.CanSeek; }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && baseStream != null)
            {
                baseStream.Dispose();
            }
            baseStream = null;
            base.Dispose(disposing);
        }
        public override void Close()
        {
            if (baseStream != null) baseStream.Close();
            base.Close();
        }
        public override int ReadByte()
        {
            int val = BaseStream.ReadByte();
            if (val >= 0) Increment(1);
            return val;
        }
        public override void WriteByte(byte value)
        {
            BaseStream.WriteByte(value);
            Increment(1);
        }
    
    }
    static class Program
    {
        static void Main()
        {
            /* invent some big data */
            const string path = "bigfile";
            if (File.Exists(path)) File.Delete(path);
            using (var chatty = new ChattyStream(File.Create(path)))
            {
                chatty.ProgressChanged += delegate
                {
                    Console.WriteLine("Writing: " + chatty.Position);
                };
                using (var writer = XmlWriter.Create(chatty))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("xml");
                    for (int i = 0; i < 50000; i++)
                    {
                        writer.WriteElementString("add", i.ToString());
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                chatty.Close();
            }
            
    
            /* read it */
    
            using (var chatty = new ChattyStream(File.OpenRead("bigfile")))
            {
                chatty.ProgressChanged += delegate
                {
                    Console.WriteLine("Reading: " + chatty.Position);
                };
    
                // now read "chatty" with **any** API; XmlReader, XmlDocument, XDocument, etc
                XmlDocument doc = new XmlDocument();
                doc.Load(chatty);
            }
        }
    }
