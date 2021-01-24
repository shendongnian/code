    public static string DumpList2(string prefix, object input)
    {
       if (input is object[] ary)
          return string.Join("\r\n", ary.Select((value, i) => DumpList2($"{prefix}.{i}", value)));
       return $"{prefix}.{input}";             
    }
