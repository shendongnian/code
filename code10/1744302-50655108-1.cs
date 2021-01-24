    public unsafe class Mine2 : Benchmark<List<string>, char>
    {
       protected override char InternalRun()
       {
          var result = new int[10];
          var current = new int[10];
          var raw = string.Join(" ", Input);
    
          fixed (char* pInput = raw)
          {
             var len = pInput + raw.Length;
             for (var p = pInput; p < len; p++)
                if (*p != ' ')
                   current[*p - 48]++;
                else
                   for (var i = 0; i < 10; i++)
                   {
                      result[i] += current[i];
                      current[i] = 0;
                   }
     
          }
    
          return (char)(result.ToList().IndexOf(result.Max()) + '0');
       }
    }
