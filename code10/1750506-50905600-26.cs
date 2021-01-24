    private static unsafe void Write(double[,] ary, int chunkSize, string fileName)
    {
       var h = ary.GetLength(0);
       var w = ary.GetLength(1);
       var totalSize = h * w;
       var s = chunkSize / sizeof(double);
       using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, chunkSize))
       {
          var handle = default(GCHandle);
    
          try
          {
             handle = GCHandle.Alloc(ary, GCHandleType.Pinned);
             var p = (long*)handle.AddrOfPinnedObject()
                                  .ToPointer();
             var fileHandle = fs.SafeFileHandle.DangerousGetHandle();
    
             for (var i = 0; i < totalSize; i += s)
             {
                var size = Math.Min(s, totalSize - i);
                var p2 = p + i;
                Kernel32.WriteFile(fileHandle, (IntPtr)p2, size * sizeof(double), out var n, IntPtr.Zero);
             }
          }
          finally
          {
             if (handle.IsAllocated)
             {
                handle.Free();
             }
          }
       }
    }
