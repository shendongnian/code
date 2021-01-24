    [Test("BlockCopy", "", true)]
    public double[] Test1(double[] input, int scale)
    {
       var result = new double[scale];
       Buffer.BlockCopy(input, 0, result, 0, input.Length);
       return result;
    }
    
    [Test("ArrayCopy", "", false)]
    public  double[] Test2(double[] input, int scale)
    {
       var result = new double[scale];
       Array.Copy(input, 0, result, 0, input.Length);
       return result;
    }
    
    [Test("ElemCopy", "", false)]
    public  double[] Test3(double[] input, int scale)
    {
       var result = new double[scale];
       for (var i=0; i <input.Length; i++)
          result[i] = input[i];
       return result;
    }
    [Test("ElemCopy Unsafe", "", false)]
    unsafe public  double[] Test4(double[] input, int scale)
    {
       var result = new double[scale];
       fixed(double* pInput = input, pResult = result)
       for (var i=0; i <input.Length; i++)
          *(pResult+i) = *(pResult+i);
       return result;
    }
