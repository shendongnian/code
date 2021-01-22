    public IEnumerable<string> ConcatLists(params IEnumerable<string>[] lists)
    {
      foreach (IEnumerable<string> list in lists)
      {
        foreach (string s in list)
        {
          yield return s;
        }
      }
    }
