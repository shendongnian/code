    class MyNativeList<T> : NativeList<T>
    {
        protected readonly Action _disposalCallback;
        public MyNativeList(Action disposalCallback) : base()
        {
            _disposalCallback = disposalCallback;
        }
        public override Dispose()
        {
            _disposalCallback();
            base.Dispose();
        }
    }
