    using System.IO;
    using System.Threading;
    using System.Collections.Concurrent;
    
    public class EchoStream : MemoryStream
    {
        public int ReadTimeoutMilliseconds { get; set; } = Timeout.Infinite;
        public bool AlwaysCopyBuffer { get; set; } = false;
    
        private readonly AutoResetEvent _DataReady = new AutoResetEvent(false);
        private readonly AutoResetEvent _DataFull = new AutoResetEvent(false);
        private readonly Object _lock = new Object();
    
        private readonly ConcurrentQueue<byte[]> _Buffers = new ConcurrentQueue<byte[]>();
        private int _maxQueueDepth = 10;
    
        private byte[] m_buffer = null;
        private int m_offset = 0;
        private int m_count = 0;
    
        public bool DataAvailable { get { return !_Buffers.IsEmpty; } }
    
        public EchoStream() : base(256)
        {
        }
    
        public EchoStream(int maxQueueDepth) : base(256)
        {
            _maxQueueDepth = maxQueueDepth;
        }
    
        public override void Write(byte[] buffer, int offset, int count)
        {
            while (_maxQueueDepth > 0 && _Buffers.Count >= _maxQueueDepth)
            {
                _DataFull.WaitOne();
            }
    
            if(!AlwaysCopyBuffer && offset==0 && count==buffer.Length)
            {
                _Buffers.Enqueue(buffer); //optimization if entire buffer is to be used
            }
            else
            {
                _Buffers.Enqueue(buffer.Skip(offset).Take(count).ToArray());
            }
            _DataReady.Set();
        }
    
        public override int Read(byte[] buffer, int offset, int count)
        {
            lock(_lock)
            {
                if (_Buffers.Count == 0)
                {
                    _DataReady.Reset();
                    if (_Buffers.Count == 0) //check count again after resetting event to avoid a race condition
                    {
                        if(!_DataReady.WaitOne(ReadTimeoutMilliseconds)) return 0;
                    }
                }
    
                int returnBytes = 0;
                while (count > 0)
                {
                    if (m_count == 0)
                    {
                        byte[] lBuffer = null;
                        if (_Buffers.TryDequeue(out lBuffer))
                        {
                            _DataFull.Set();
                            m_buffer = lBuffer;
                            m_offset = 0;
                            m_count = lBuffer.Length;
                        }
                        else
                        {
                            return returnBytes = 0 ? -1 : returnBytes;
                        }
                    }
    
                    var bytesToCopy = (count < m_count) ? count : m_count);
                    if (m_offset == 0 && offset == 0 && m_count == count)
                    {
                        buffer = m_buffer; //optimization if the entire buffer is to be copied
                    }
                    else
                    {
                        Buffer.BlockCopy(m_buffer, m_offset, buffer, offset, bytesToCopy);
                    }
                    m_offset += bytesToCopy;
                    m_count -= bytesToCopy;
                    offset += bytesToCopy;
                    count -= bytesToCopy;
    
                    returnBytes += bytesToCopy;
                }
    
                return returnBytes;
            }
        }
    }
