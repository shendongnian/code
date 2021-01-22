    string StringFold(string input, Func<char, string> proc)
    {
      return string.Concat(input.Select(proc).ToArray());
    }
    
    string FoldProc(char input)
    {
      if (input >= 128)
      {
        return string.Format(@"\u{0:x4}", (int)input);
      }
      return input.ToString();
    }
    
    string EscapeToAscii(string input)
    {
      return StringFold(input, FoldProc);
    }
