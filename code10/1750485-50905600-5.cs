    public class BlockCopy : Benchmark<int, int>
    {
       private static void Write(double[,] ary, int chunkSize, string fileName)
       {
          var h = ary.GetLength(0);
          var w = ary.GetLength(1);
    
          var totalSize = h * w;
          var buffSize = chunkSize * sizeof(double);
    
          using (var fs = new FileStream(
                                           fileName,
                                           FileMode.Create, // create or overwrite existing file
                                           FileAccess.Write, // write-only access
                                           FileShare.None,
                                           buffSize))
          {
             var buffer = new byte[buffSize];
    
             for (var i = 0; i < totalSize; i += buffSize)
             {
                var size = Math.Min(buffSize, totalSize - i);
                Buffer.BlockCopy(ary, i, buffer, 0, size);
                fs.Write(buffer, 0, size);
             }
          }
       }
    }
