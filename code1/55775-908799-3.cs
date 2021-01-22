    public class ComFileCritical : BaseCriticalResource {
    
        private IntPtr nativeResource;
        protected override Dispose(bool disposing) {
            // free native resources if there are any.
            if (nativeResource != IntPtr.Zero) {
                ComCallToFreeUnmangedPointer(nativeResource);
                nativeResource = IntPtr.Zero;
            }
        }
    }
      
