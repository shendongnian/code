    class MyStream : Stream {
        private readonly Stream _source;
        private readonly IDisposable _parent;
        public MyStream(Stream, IDisposable) {...assign...}
        // not shown: Implement all Stream methods via `_source` proxy
        public override void Dispose()
        {
            _source.Dispose();
            _parent.Dispose();
        }
    }
