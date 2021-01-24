    public unsafe class Mine : Benchmark<List<string>, char>
    {
       protected override char InternalRun()
       {
          var result = new int[10];
          var asd = Input.Select(x => new string(x.Distinct().ToArray())).ToList();
          var raw = string.Join("", asd);
    
          fixed (char* pInput = raw)
          {
             var len = pInput + raw.Length;
             for (var p = pInput; p < len; p++)
             {
                result[*p - 48]++;
             }
          }
    
          return (char)(result.ToList().IndexOf(result.Max()) + '0');
       }
    }
