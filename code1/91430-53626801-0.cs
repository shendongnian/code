    public class EchoStream : MemoryStream
{
    private readonly ManualResetEvent _DataReady = new ManualResetEvent(false);
    private readonly ManualResetEvent _DataFull = new ManualResetEvent(false);
    private readonly ConcurrentQueue<byte[]> _Buffers = new ConcurrentQueue<byte[]>();
    private _maxQueueDeptch = 10;
    private byte[] m_buffer = null;
    private int m_offset = 0;
    private int m_count = 0;
    public bool DataAvailable { get { return !_Buffers.IsEmpty; } }
    public void EchoStream() : base(256)
    {
    }
    public void EchoStream(int maxQueueDepth) : base(256)
    {
        _maxQueueDepth = maxQueueDepth;
    }
    public override void Write(byte[] buffer, int offset, int count)
    {
        while (_maxQueueDepth > 0 && _Buffers.Count >= _maxQueueDepth)
        {
            _DataFull.WaitOne();
            _DataFull.Reset();
        }
        if(offset==0 && count==buffer.Length)
        {
            _Buffers.Enqueue(buffer);
        }
        else
        {
            _Buffers.Enqueue(buffer.Skip(offset).Take(count).ToArray());
        }
        _DataReady.Set();
    }
    public override int Read(byte[] buffer, int offset, int count)
    {
        _DataReady.WaitOne();
        while (count > 0)
        {
            if (m_count == 0)
            {
                if (_Buffers.TryDequeue(out lBuffer))
                {
                    _DataFull.Set();
                    m_buffer = lBuffer;
                    m_offset = 0;
                    m_count = lBuffer.Length;
                }
                else
                {
                    _DataReady.Reset();
                    return -1;
                }
            }
            var bytesToCopy = (count < m_count) ? count : m_count);
            Buffer.BlockCopy(m_buffer, m_offset, buffer, offset, bytesToCopy);
            m_offset += bytesToCopy;
            m_count -= bytesToCopy;
            offset += bytesToCopy;
            count -= bytesToCopy;
        }
        if (!DataAvailable)
            _DataReady.Reset();
        return lBuffer.Length;
    }
