    public sealed class MyReturn<TEntity> : IDisposable
    {
        public string Message { get; set; }
        public TEntity Entity { get; set; }
        public string SysException { get; set; }
        // and etc...
        public void Dispose() {}
    }
