    /// <summary>
    /// Analyze the given lines of text and try to determine the correct delimiter used. If multiple
    /// candidate delimiters are found, the highest frequency delimiter will be returned.
    /// </summary>
    /// <example>
    /// string discoveredDelimiter = DetectDelimiter(dataLines, new char[] { '\t', '|', ',', ':', ';' });
    /// </example>
    /// <param name="lines">Lines to inspect</param>
    /// <param name="delimiters">Delimiters to search for</param>
    /// <returns>The most probable delimiter by usage, or null if none found.</returns>
    public string DetectDelimiter(IEnumerable<string> lines, IEnumerable<char> delimiters) {
      Dictionary<char, int> delimFrequency = new Dictionary<char, int>();
    
      // Setup our frequency tracker for given delimiters
      delimiters.ToList().ForEach(curDelim => 
        delimFrequency.Add(curDelim, 0)
      );
    
      // Get a total sum of all occurrences of each delimiter in the given lines
      delimFrequency.ToList().ForEach(curDelim => 
        delimFrequency[curDelim.Key] = lines.Sum(line => line.Count(p => p == curDelim.Key))
      );
    
      // Find delimiters that have a frequency evenly divisible by the number of lines
      // (correct & consistent usage) and order them by largest frequency
      var possibleDelimiters = delimFrequency
                        .Where(f => f.Value > 0 && f.Value % lines.Count() == 0)
                        .OrderByDescending(f => f.Value)
                        .ToList();
    
      // If more than one possible delimiter found, return the most used one
      if (possibleDelimiters.Any()) {
        return possibleDelimiters.First().Key.ToString();
      }
      else {
        return null;
      }   
    
    }
