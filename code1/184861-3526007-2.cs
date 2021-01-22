    class HGlobal : SafeBuffer
    {
        public HGlobal(int cb)
            : base(true)
        {
            this.SetHandle(Marshal.AllocHGlobal(cb));
            this.Initialize((ulong)cb);
        }
        protected override bool ReleaseHandle()
        {
            Marshal.FreeHGlobal(this.handle);
            return true;
        }
    }
