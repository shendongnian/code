    // Read sentences from text file (each sentence on a separate line)
    IEnumerable<string> lines = File.ReadLines(inputPath);
    // Call method below
    lines = CapitalizeFirstLetterOfEachWord(lines);
	
    private static IEnumerable<string> CapitalizeFirstLetterOfString(IEnumerable<string> inputLines)
    {
      // Will output: Lorem lipsum et
      List<string> outputLines = new List<string>();
      TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
      foreach (string line in inputLines)
      {
        string lineLowerCase = textInfo.ToLower(line);
        string[] lineSplit = lineLowerCase.Split(' ');
        bool first = true;
       for (int i = 0; i < lineSplit.Length; i++ )
        {
          if (first)
          {
            lineSplit[0] = textInfo.ToTitleCase(lineSplit[0]);
            first = false;
          }
        }
        outputLines.Add(string.Join(" ", lineSplit));
      }
      return outputLines;
   }
