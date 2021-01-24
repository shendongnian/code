    public unsafe (double[], double[]) Test2(byte[] input, int scale)
    {
       var bufferA = new double[input.Length / 4];
       var bufferB = new double[input.Length / 4];
    
       fixed (byte* pSource = input)
          fixed (double* pBufferA = bufferA, pBufferB = bufferB)
          {
             var pLen = pSource + input.Length;
             double* pA = pBufferA, pB = pBufferB;
    
             for (var pS = pSource; pS < pLen; pS += 4, pA++, pB++)
             {
                *pA = *(short*)pS;
                *pB = *(short*)(pS + 2);
             }
          }
    
       return (bufferA, bufferB);
    }
