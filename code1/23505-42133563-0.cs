    public class ThrottledStream : Stream
    {
        private readonly Stream parent;
        private readonly int maxBytesPerSecond;
        private readonly IScheduler scheduler;
        private readonly IStopwatch stopwatch;
        private long processed;
        public ThrottledStream(Stream parent, int maxBytesPerSecond, IScheduler scheduler)
        {
            this.maxBytesPerSecond = maxBytesPerSecond;
            this.parent = parent;
            this.scheduler = scheduler;
            stopwatch = scheduler.StartStopwatch();
            processed = 0;
        }
        public ThrottledStream(Stream parent, int maxBytesPerSecond)
            : this (parent, maxBytesPerSecond, Scheduler.Immediate)
        {
        }
        protected void Throttle(int bytes)
        {
            processed += bytes;
            var targetTime = TimeSpan.FromSeconds((double)processed / maxBytesPerSecond);
            var actualTime = stopwatch.Elapsed;
            var sleep = targetTime - actualTime;
            if (sleep > TimeSpan.Zero)
            {
                using (var waitHandle = new AutoResetEvent(initialState: false))
                {
                    scheduler.Sleep(sleep).GetAwaiter().OnCompleted(() => waitHandle.Set());
                    waitHandle.WaitOne();
                }
            }
        }
        public override bool CanRead
        {
            get { return parent.CanRead; }
        }
        public override bool CanSeek
        {
            get { return parent.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return parent.CanWrite; }
        }
        public override void Flush()
        {
            parent.Flush();
        }
        public override long Length
        {
            get { return parent.Length; }
        }
        public override long Position
        {
            get
            {
                return parent.Position;
            }
            set
            {
                parent.Position = value;
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            var read = parent.Read(buffer, offset, count);
            Throttle(read);
            return read;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return parent.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            parent.SetLength(value);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            Throttle(count);
            parent.Write(buffer, offset, count);
        }
    }
