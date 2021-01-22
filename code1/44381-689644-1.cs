    public IEnumerable<char> MakeNice(IEnumerable<char> str)
    {
      foreach (var chr in str)
      {
        if (char.ToUpper(chr) == chr)
        {
          yield return ' ';
        }
        yield return chr;
      }
    }
    public string MakeNiceString(string str)
    {
      return new string(MakeNice(str)).Trim();
    }
