    private static void StaticWriteArray(double[,] ary, string fileName)
    {
       var h = ary.GetLength(0);
       var w = ary.GetLength(1);
    
       var totalSize = h * w;
       const int Chunk = 1024 * 4;
       const int Bytesize = Chunk * sizeof(double);
       using (var fs = new FileStream(fileName, FileMode.Create))
       {
          var buffer = new byte[Bytesize];
    
          for (var i = 0; i < totalSize; i += Chunk)
          {
             var size = Math.Min(Chunk, totalSize - i) * sizeof(double);
             Buffer.BlockCopy(ary, i, buffer, 0, size);
             fs.Write(buffer, 0, size);
          }
       }
    }
