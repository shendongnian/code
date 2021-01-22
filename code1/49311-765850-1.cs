    public T Read<T>() where T : struct {
      // An T[] would be a reference type, and alot easier to work with.
      T[] t = new T[1];
  
      // Marshal.SizeOf will fail with types of unknown size. Try and see...
      int s = Marshal.SizeOf(typeof(T));
      if (_index + s > _size)
        // Should throw something more specific.
        throw new Exception("Error 101");
      // Grab a handle of the array we just created, pin it to avoid the gc
      // from moving it, then copy bytes from our stream into the address
      // of our array.
      GCHandle handle = GCHandle.Alloc(t, GCHandleType.Pinned);
      Marshal.Copy(_stream, _index, handle.AddrOfPinnedObject(), s);
      _index += s;
  
      // Return the first (and only) element in the array.
      return t[0];
    }
