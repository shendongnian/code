    public static void DumpList2(string prefix, object input, List<string> result)
    {
       if (!(input is Array))
       {
          result.Add($"{prefix}.0.{input}");
          return;
       }
    
       var ary = (object[])input;
    
       for (var i = 0; i < ary.Length; i++)
          if (!(ary[i] is Array))
             result.Add($"{prefix}.{i}.{ary[i]}");
          else
             DumpList2($"{prefix}.{i}", ary[i], result);
             
    }
