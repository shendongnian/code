    class MyNativeList<T> : NativeList<T>
    {
        protected readonly Action _callAfterDisposal;
        public MyNativeList(Action callAfterDisposal) : base()
        {
            _callAfterDisposal= callAfterDisposal;
        }
        public override Dispose()
        {
            base.Dispose();
            _callAfterDisposal();
        }
    }
