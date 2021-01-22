    private void WriteLine<T>(StreamWriter sr, IEnumerable<T> line)
    {
      using(var en = line.GetEnumerator())
      if(en.MoveNext())
      {
        WriteItem(sr, en.Current);
        while(en.MoveNext())
        {
          sr.Write(',');
          WriteItem(sr, en.Current);
        }
    }
    private void WriteCSV<T>(StreamWriter sr, IEnumerable<IEnumerable<T>> allLines)
    {
        using(var en = allLines.GetEnumerator())
        if(en.MoveNext())
        {
          WriteLine(sr, en.Current);
          while(en.MoveNext())
          {
            sr.Write('\n');
            WriteLine(sr, en.Current);
          }
        }
    }
