    private static void Write(double[,] ary, int chunkSize, string fileName)
    {
       var h = ary.GetLength(0);
       var w = ary.GetLength(1);
    
       using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, chunkSize))
          using (var bw = new BinaryWriter(fs))
             for (var i = 0; i < h; i++)
                for (var j = 0; j < w; j++)
                    bw.Write(ary[i, j]);
    }
