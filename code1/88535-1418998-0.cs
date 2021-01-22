     public void Dispose() { Dispose(true); }
     ~MemBlock() { Dispose(false); }
     void Dispose(bool disposing) { // would be protected virtual if not sealed 
         if(disposing) { // only run this logic when Dispose is called
             GC.SuppressFinalize(this);
             // and anything else that touches managed objects
         }
         if (ptr != IntPtr.Zero) {
              Marshal.FreeHGlobal(ptr);
              ptr = IntPtr.Zero;
         }
     }
     
