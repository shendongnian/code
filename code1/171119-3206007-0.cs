    private IEnumerable<string> GetLinesFromFile(string fileName)
    {
      using (var streamReader = new StreamReader(fileName))
      {
        string line = null;
        bool previousLineWasBlank = false;
        while ((line = streamReader.ReadLine()) != null)
        {
          if (!previousLineWasBlank && string.IsNullOrEmpty(line))
          {
            yield return line;
          }
        
          previousLineWasBlank = string.IsNullOrEmpty(line);
        }
      }
    }
