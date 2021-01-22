    public static class NativeMethods {
    
      [DllImport("kernel32")]
      private unsafe static extern void* LoadLibrary(string dllname);
    
      [DllImport("kernel32")]
      private unsafe static extern void FreeLibrary(void* handle);
    
      private sealed unsafe class LibraryUnloader
      {
        internal LibraryUnloader(void* handle)
        {
          this.handle = handle;
        }
    
        ~LibraryUnloader()
        {
          if (handle != null)
            FreeLibrary(handle);
        }
    
        private void* handle;
    
      } // LibraryUnloader
    
    
      private static readonly LibraryUnloader unloader;
    
      static NativeMethods()
      {
        string path;
        // set the path according to some logic
        path = "somewhere/in/a/temporary/directory/Foo.dll";    
        unsafe
        {
          void* handle = LoadLibrary(path);
    
          if (handle == null)
            throw new DllNotFoundException("unable to find the native Foo library: " + path);
    
          unloader = new LibraryUnloader(handle);
        }
      }
    }
