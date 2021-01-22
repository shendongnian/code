    public static IEnumerable<string> GetText(string filePath)
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ( (line = sr.ReadLine()) != null)
            {
               if (line.IndexOf("+CMGL") < 0) yield return line;
            }
        }
    }
