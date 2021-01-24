    fixed (char* pInput = Input)
    {
       var len = pInput + Input.Length;
       var current = 0;
       var results = new List<int>();
    
       for (var p = pInput; p < len; p++)
       {
          if (*p >= 48 & *p <= 58)
             current = current * 10 + *p - 48;          
          else if (*p == ',')
          {
             results.Add(current);
             current = 0;
          }
       }
    
       results.Add(current);
       return results;
    }
