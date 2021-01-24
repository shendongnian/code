    public static string DumpList(string prefix, object input)
    {
       if (input is object[] array)
          return String.Join("\r\n", ary.Select((value, i) => DumpList($"{prefix}.{i}", value)));
       return $"{prefix}.{input}";             
    }
