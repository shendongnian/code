    public static IEnumerable<List<string>> ParseFields(string file)
    {
      // Use "using" to clean up the parser.
      using (var parser = new TextFieldParser(file))
      {
        parser.Delimiters = new string[] { "," };
        // Use end-of-data, not checks for null.
        while (!parser.EndOfData)
          yield return parser.ReadFields().ToList();
      }
    }
