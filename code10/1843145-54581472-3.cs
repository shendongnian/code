    internal class CDriver : IDisposable {
        private IntPtr cdriver;
        public CDriver(string registry)
        {
            cdriver = CreateCDriver("whatever");
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SupressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            DestroyCDriver(cdriver);
            cdriver = IntPtr.Zero;
        }
    }
