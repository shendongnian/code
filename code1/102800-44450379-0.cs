    class FakeStreamer : Stream
    {
        public bool bExit = false;
        Stream stream;
        TcpClient client;
        public FakeStreamer(TcpClient client)
        {
            this.client = client;
            this.stream = client.GetStream();
            this.stream.ReadTimeout = 100; //100ms
        }
        public override bool CanRead
        {
            get { return stream.CanRead; }
        }
        public override bool CanSeek
        {
            get { return false; }
        }
        public override bool CanWrite
        {
            get { return stream.CanWrite; }
        }
        public override long Length
        {
            get { return -1L; }
        }
        public override long Position
        {
            get { return 0L; }
            set { }
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return 0L;
        }
        public override void SetLength(long value)
        {
            stream.SetLength(value);
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int len = 0, c = count;
            while (c > 0 && !bExit)
            {
                try
                {
                    len = stream.Read(buffer, offset, c);
                }
                catch (Exception e)
                {
                    if (e.HResult == -2146232800) // Timeout
                    {
                        continue;
                    }
                    else
                    {
                        //Exit read loop
                        break;
                    }
                }
                if (!client.Connected || len == 0)
                {
                    //Exit read loop
                    return 0;
                }
                offset += len;
                c -= len;
            }
            return count;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            stream.Write(buffer,offset,count);
        }
        public override void Close()
        {
            stream.Close();
            base.Close();
        }
        public override void Flush()
        {
            stream.Flush();
        }
    }
