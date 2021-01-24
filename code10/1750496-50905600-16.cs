    private static unsafe void Write(double[,] ary, int chunkSize, string fileName)
    {
       // Get Dimensions
       var h = ary.GetLength(0);
       var w = ary.GetLength(1);
    
       var totalSize = h * w;
       var chunks = totalSize / chunkSize;
    
       fixed (double* pAry = ary)
       {          
          // Copy to use in lambda
          var p = pAry;
    
          // start the Parallel for
          Parallel.For(0, chunks, Workload);
    
          void Workload(int i)
          {
             using (var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write, chunkSize, FileOptions.Asynchronous))
             {
                var safeHandle = fs.SafeFileHandle;
    
                if (safeHandle == null)
                   return;
    
                var fileHandle = safeHandle.DangerousGetHandle();
    
                // Chunk count * the size of the chunk, converted to bytes
                fs.Position = i * chunkSize * sizeof(double);
    
                var copySize = Math.Min(chunkSize, totalSize - i * chunkSize);
                p += i * chunkSize;
                
                Kernel32.WriteFile(fileHandle, (IntPtr)p, copySize, out var n, IntPtr.Zero);
                fs.Flush();
             }
          }
       }
    }
