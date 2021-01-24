    [Test("MineR", "", false)]
    public int[] Test3(byte[] input, int scale)
    {
       int numBytes = input.Length;
       int numInts = numBytes / 4;
    
       if (numBytes / 4d != numInts)
          throw new Exception();
    
       if (numInts == 0)
          return new int[0];
    
       var ints = new int[numInts];
    
       unsafe
       {
          fixed (byte* pBytes = input)
             fixed (int* pInts = ints)
             {
                byte* rawInt = (byte*)pInts;
    
                for (int i = 0; i < numBytes; i += 4)
                {
                   for (int j = 0; j < 4; j++)
                   {
                      rawInt[i + j] = pBytes[3 - j + i];
                   }
                }
    
             }
       }
    
       return ints;
    }
