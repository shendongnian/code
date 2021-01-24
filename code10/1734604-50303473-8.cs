    public static void DumpList2(string prefix, object input, List<string> result)
    {
       if (input is object[] ary)
          for (var i = 0; i < ary.Length; i++)
             if (ary[i] is Array)
                DumpList2($"{prefix}.{i}", ary[i], result);
             else
                result.Add($"{prefix}.{i}.{ary[i]}");
       else
          result.Add($"{prefix}.0.{input}");
    }
