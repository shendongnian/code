    List<List<string>> Parse(string file)
    {
      List<List<string>> result = new List<List<string>>();
      using (TextReader reader = File.OpenText(file))
      {
        string line = reader.ReadLine();
        while (line != null)
        {
          result.Add(new List<string>(line.Split(',')));
          line = reader.ReadLine();
        }
      }
      return result;
    }
