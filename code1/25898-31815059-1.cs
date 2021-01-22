    public static bool IsSameFile(string path1, string path2)
    {
      IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
      IntPtr handle1 = NativeMethods.CreateFile(path1, FileAccess.Read, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
      if (handle1 == INVALID_HANDLE_VALUE)
        throw new IOException(string.Format("CreateFile has failed on {0}", path1));
      IntPtr handle2 = NativeMethods.CreateFile(path2, FileAccess.Read, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
      if (handle2 == INVALID_HANDLE_VALUE)
        throw new IOException(string.Format("CreateFile has failed on {0}", path2));
      using (var sfh1 = new SafeFileHandle(handle1, true))
      using (var sfh2 = new SafeFileHandle(handle2, true))
      {
        NativeMethods.BY_HANDLE_FILE_INFORMATION fileInfo1;
        bool result1 = NativeMethods.GetFileInformationByHandle(sfh1, out fileInfo1);
        if (!result1)
          throw new IOException(string.Format("GetFileInformationByHandle has failed on {0}", path1));
        NativeMethods.BY_HANDLE_FILE_INFORMATION fileInfo2;
        bool result2 = NativeMethods.GetFileInformationByHandle(sfh2, out fileInfo2);
        if (!result2)
          throw new IOException(string.Format("GetFileInformationByHandle has failed on {0}", path2));
        return fileInfo1.VolumeSerialNumber == fileInfo2.VolumeSerialNumber
          && fileInfo1.FileIndexHigh == fileInfo2.FileIndexHigh
          && fileInfo1.FileIndexLow == fileInfo2.FileIndexLow;
      }
    }
