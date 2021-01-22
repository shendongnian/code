    class AutoPinner : IDisposable
    {
       GCHandle _pinnedArray;
       public AutoPinner(Object obj)
       {
          _pinnedArray = GCHandle.Alloc(obj, GCHandleType.Pinned);
       }
       public static implicit operator IntPtr(AutoPinner ap)
       {
          return ap._pinnedArray.AddrOfPinnedObject(); 
       }
       public void Dispose()
       {
          _pinnedArray.Free();
       }
    }
