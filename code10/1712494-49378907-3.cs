    public static IEnumerable<string> AllSubstrings(string value) {
      if (value == null) 
        yield break; // Or throw ArgumentNullException
      for (int length = 1; length < value.Length; ++length)
        for (int start = 0; start <= value.Length - length; ++start)
          yield return value.Substring(start, length);
    }
