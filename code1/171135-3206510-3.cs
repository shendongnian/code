    [DllImport("kernel32.dll", SetLastError=true)]
    [return:MarshalAs(UnmanagedType.Bool)]
    static extern bool ReadFile(IntPtr handle, IntPtr buffer, uint numBytesToRead, out uint numBytesRead, IntPtr overlapped);
    [DllImport("kernel32.dll", SetLastError=true)]
    [return:MarshalAs(UnmanagedType.Bool)]
    static extern bool SetFilePointerEx(IntPtr hFile, long liDistanceToMove, out long lpNewFilePointer, uint dwMoveMethod);
    unsafe bool read(FileStream fs, ushort[] buffer, int offset, int count)
    {
      if (null == fs) throw new ArgumentNullException();
      if (null == buffer) throw new ArgumentNullException();
      if (offset < 0 || count < 0 || offset + count > buffer.Length) throw new ArgumentException();
      uint bytesToRead = 2 * count;
      if (bytesToRead < count) throw new ArgumentException(); // detect integer overflow
      long offset = fs.Position;
      SafeFileHandle nativeHandle = fs.SafeFileHandle; // clears Position property
      try {
        long unused;
        if (!SetFilePositionEx(nativeHandle, offset, out unused, 0);
        fixed (ushort* pFirst = &buffer[offset])
          if (!ReadFile(nativeHandle, new IntPtr(pFirst), bytesToRead, out bytesToRead, IntPtr.Zero)
            return false;
        if (bytesToRead < 2 * count)
          return false;
        offset += bytesToRead;
        return true;
      }
      finally {
        fs.Position = offset; // restore Position property
      }
    }
