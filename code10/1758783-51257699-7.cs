    [Test("john", "", false)]
    public unsafe int[] Test4(byte[] input, int scale)
    {
       var result = new int[input.Length / 4];
       for (int i = 0; i < result.Length; ++i)
       {
          var srcBytes = input.Skip(i * 4).Take(4);
          if (System.BitConverter.IsLittleEndian)
          {
             srcBytes = srcBytes.Reverse();
          }
          result[i] = System.BitConverter.ToInt32(srcBytes.ToArray(), 0);
       }
    
       return result;
    }
