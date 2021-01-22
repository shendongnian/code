    public class EchoStream : MemoryStream
    {
        private readonly ManualResetEvent _DataReady = new ManualResetEvent(false);
        private readonly ConcurrentQueue<byte[]> _Buffers = new ConcurrentQueue<byte[]>();
        public bool DataAvailable{get { return !_Buffers.IsEmpty; }}
        public override void Write(byte[] buffer, int offset, int count)
        {
            _Buffers.Enqueue(buffer);
            _DataReady.Set();
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            _DataReady.WaitOne();
            byte[] lBuffer;
            if (!_Buffers.TryDequeue(out lBuffer))
            {
                _DataReady.Reset();
                return -1;
            }
            if (!DataAvailable)
                _DataReady.Reset();
            Array.Copy(lBuffer, buffer, lBuffer.Length);
            return lBuffer.Length;
        }
    }
