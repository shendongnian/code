    private static void Write(double[,] ary, int chunkSize, string fileName)
    {
       var h = ary.GetLength(0);
       var w = ary.GetLength(1);
       var totalSize = h * w * sizeof(double);
    
       using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, chunkSize))
       {
          var buffer = new byte[chunkSize];
    
          for (var i = 0; i < totalSize; i += chunkSize)
          {
             var size = Math.Min(chunkSize, totalSize - i);
             Buffer.BlockCopy(ary, i, buffer, 0, size);
             fs.Write(buffer, 0, size);
          }
       }
    }
