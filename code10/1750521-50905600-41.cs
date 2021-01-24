    private static void Read(double[,] ary, int chunkSize, string fileName)
    {
       var h = ary.GetLength(0);
       var w = ary.GetLength(1);
       var totalSize = h * w * sizeof(double);
    
       using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None, chunkSize))
       {
          var buffer = new byte[chunkSize];
    
          for (var i = 0; i < totalSize; i += chunkSize)
          {
             var size = Math.Min(chunkSize, totalSize - i);
      
             fs.Read(buffer, 0, size);
             Buffer.BlockCopy(buffer,0,ary , i, size);
          }
       }
    }
