    public static IEnumerable<string> ReadLines(string filePath)
    {
        using (var rdr = new StreamReader(filePath))
        {
           string line;
           while ( (line = rdr.ReadLine()) != null)  // <-----
           {
              yield return line;
           }
        }
    }
