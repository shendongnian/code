    [Test("Mine2", "", false)]
    public unsafe int[] Test2(byte[] input, int scale)
    {
       var result = new int[input.Length / 4];
       Buffer.BlockCopy(input, 0, result, 0, input.Length);
    
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
