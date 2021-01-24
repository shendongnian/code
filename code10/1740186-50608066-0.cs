    static IEnumerable<string> Mutate(string input)
    {
      if (input == null || input.Length == 0) { yield break; }
      yield return input;
      int pos = 0;
      while (pos < input.Length)
      {
        int index = input.IndexOf("Stop", pos);
        if (index == -1 || index == input.Length - 4) { break; }
        index += 4;
        yield return input.Substring(index);
        pos = index;
      }
    }
