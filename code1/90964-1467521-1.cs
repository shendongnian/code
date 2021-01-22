    string MagicFunction(string input)
    {
      StringBuilder sb = new StringBuilder();
      StringReader sr = new StringReader(input);
      string line = null;
      using(StringReader sr = new StringReader(input))
      {
        while((line = sr.ReadLine()) != null)
        {
          sb.Append(String.Concat("-- ", line, System.Environment.NewLine));
        }
      }
      return sb.ToString();
    }
