    public class ConcurrentBuffer
    {
        private readonly byte[] buffer;
        internal byte[] GetBuffer() { return buffer; }
        private List<BufferLock> locks = new List<BufferLock>();
        public ConcurrentBuffer(int bufferSize)
        {
            buffer = new byte[bufferSize];
        }
        public BufferLock AcquireLock(int startIndex, int endIndex)
        {
            if (startIndex < 0) throw new ArgumentOutOfRangeException("startIndex");
            if (startIndex > endIndex || endIndex >= buffer.Length) throw new ArgumentOutOfRangeException("endIndex");
            lock (buffer)
            {
                foreach (var l in locks)
                {
                    if (!(endIndex < l.StartIndex || startIndex > l.EndIndex))
                    {
                        return null;
                    }
                }
                var bl = new BufferLock(startIndex, endIndex, this);
                locks.Add(bl);
                return bl;
            }
        }
        public void ReleaseLock(BufferLock lck)
        {
            lock (buffer)
            {
                locks.Remove(lck);
            }
        }
        public class BufferLock
        {
            public int StartIndex { get; private set; }
            public int EndIndex { get; private set; }
            public ConcurrentBuffer TargetBuffer { get; private set; }
            public MemoryStream Stream { get; private set; }
            internal BufferLock(int startIndex, int endIndex, ConcurrentBuffer buffer)
            {
                StartIndex = startIndex;
                EndIndex = endIndex;
                TargetBuffer = buffer;
                Stream = new MemoryStream(buffer.GetBuffer(), startIndex, endIndex - startIndex, true);
            }
            public void Release()
            {
                Stream.Dispose();
                TargetBuffer.ReleaseLock(this);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentBuffer cb = new ConcurrentBuffer(32000);
            byte[] myData = { 32, 13, 53, 29, 50 };
            // l1 will acquire a lock
            var l1 = cb.AcquireLock(0, 50); 
            if (l1 != null) l1.Stream.Write(myData, 0, myData.Length);
            
            // l2 will fail because l1 has part of its range locked
            var l2 = cb.AcquireLock(30, 70);
            if (l2 != null) l2.Stream.Write(myData, 0, myData.Length);
            l1.Release();
            // l3 will succeed at locking because l1 has been released
            var l3 = cb.AcquireLock(40, 5000);
            if (l3 != null)
            {
                while (l3.Stream.Position + myData.Length <= l3.Stream.Length)
                {
                    l3.Stream.Write(myData, 0, myData.Length);
                }
            }
            l3.Release();
            Console.ReadLine();
        }
    }
