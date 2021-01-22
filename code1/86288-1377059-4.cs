    public static IEnumerable<string> ReadLines(string path)
    {
        using(var sr = new StreamReader(path))
        {
           string line;
           while ( (line = sr.ReadLine()) != null)
           {
               yield return line;
           }
        }
    }
