    var list = new List<string>();
    var result = string.Empty;
    
    fixed (char* pInput = input)
    {
       var plen = pInput + input.Length;
       var toggle = true;
    
       for (var p = pInput; p < plen; p++)
       {
          if (*p == '/')
          {       
             if (result.Length > 0)
                list.Add(result);
             toggle = !toggle;
             result = string.Empty;
             continue;
          }
          if (toggle)
             result += *p;
       }
    }
    list.Add(result);
    return list.ToArray();
