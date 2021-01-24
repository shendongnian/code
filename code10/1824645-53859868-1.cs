      var s = "703.36,751.36,\"1,788.36\",887.37,891.37,\"1,850.37\",843.37,\"1,549,797.36\",818.36,749.36,705.36,0.00,\"18,979.70\",934.37";
      Regex r = new Regex("(\".*?\")|(\\d+(.\\d+)?)");
      List<double> results = new List<double>();
      foreach (Match m in r.Matches(s))
      {
        string cleanNumber = m.Value.Replace("\"", "");
        results.Add(double.Parse(cleanNumber));
      }
      Console.WriteLine(string.Join(", ", results));
