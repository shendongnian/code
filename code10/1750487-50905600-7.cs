    public class xanatos2 : Benchmark<int, int>
    {
    
       private static void Write(double[,] ary, int chunkSize, string fileName)
       {
          var h = ary.GetLength(0);
          var w = ary.GetLength(1);
    
          var totalSize = h * w;
          using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, chunkSize))
          {
             var handle = default(GCHandle);
    
             try
             {
                handle = GCHandle.Alloc(ary, GCHandleType.Pinned);
                Kernel32.WriteFile(fs.SafeFileHandle.DangerousGetHandle(), handle.AddrOfPinnedObject(), h * w * sizeof(double), out var n, IntPtr.Zero);
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
    }
