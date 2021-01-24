    public unsafe class Mine3 : Benchmark<List<string>, char>
    {
       protected override char InternalRun()
       {
          var result = new int[10];
    
          foreach (var item in Input)
             fixed (char* pInput = item)
             {
                var current = new int[10];
                var len = pInput + item.Length;
    
                for (var p = pInput; p < len; p++)
                   current[*p - 48] = 1;
    
                for (var i = 0; i < 10; i++)
                {
                   result[i] += current[i];
                   current[i] = 0;
                }
             }
             
    
          return (char)(result.ToList().IndexOf(result.Max()) + '0');
       }
    }
