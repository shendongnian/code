    public void Write<T>(T item) {
        // An T[] would be a reference type, and alot easier to work with.
        T[] t = new T[] { item };
        // Marshal.SizeOf will fail with types of unknown size. Try and see...
        int s = Marshal.SizeOf(typeof(T));
        if (_index + s > _size)
            // Should throw something more specific.
            throw new Exception("Error 101 Celebrity");
        // Grab a handle of the array we just created, pin it to avoid the gc
        // from moving it, then copy bytes from our array into the stream.
        GCHandle handle = GCHandle.Alloc(t, GCHandleType.Pinned);
        Marshal.Copy(handle.AddrOfPinnedObject(), _stream, _index, s);
        _index += s;
    }
