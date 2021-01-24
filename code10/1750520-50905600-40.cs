    private static void Write(double[,] ary, int chunkSize, string fileName)
    {
       var h = ary.GetLength(0);
       var w = ary.GetLength(1);
    
       using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, chunkSize))
          for (var i = 0; i < h; i++)
             for (var j = 0; j < w; j++)
                fs.Write(BitConverter.GetBytes(ary[i, j]), 0, 8);
    }
