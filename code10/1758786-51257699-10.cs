    public unsafe static int[] GetInts3(this byte[] source)
    {
       var result = new int[source.Length / 4];
       Buffer.BlockCopy(source, 0, result, 0, source.Length);
    
       fixed (int* pResult = result)
       {
          var len = pResult + result.Length;
    
          for (var p = pResult; p < len; p++)
          {
             var x = (*p >> 16) | (*p << 16);
             *p = (int)(((x & 0xFF00FF00) >> 8) | ((x & 0x00FF00FF) << 8));
          }
       }
    
       return result;
    }
