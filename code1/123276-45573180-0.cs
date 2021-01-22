    private static async Task<string> CalculateMD5Async(string fullFileName)
    {
      var block = ArrayPool<byte>.Shared.Rent(8192);
      try
      {
         using (var md5 = MD5.Create())
         {
             using (var stream = new FileStream(fullFileName, FileMode.Open, FileAccess.Read, FileShare.Read, 8192, true))
             {
                int length;
                while ((length = await stream.ReadAsync(block, 0, block.Length).ConfigureAwait(false)) > 0)
                {
                   md5.TransformBlock(block, 0, length, null, 0);
                }
                md5.TransformFinalBlock(block, 0, 0);
             }
             var hash = md5.Hash;
             return Convert.ToBase64String(hash);
          }
       }
       finally
       {
          ArrayPool<byte>.Shared.Return(block);
       }
    }
