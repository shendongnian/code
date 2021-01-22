    IEnumerable<string> ReadLines(string filename)
    {
        string line;
        using (var rdr = new StreamReader(filename))
            while ( (line = rdr.ReadLine()) != null)
               yield return line;
    }
    int SumXValues(string filename)
    {
        return ReadLines(filename)
                   .Where(l => int.TryParse(l.Substring(3,3)))
                   .Select(i => int.Parse(i))
                   .Where(i => i > 4 && i < 16)
                   .Take(10)
                   .Sum(i => i);
    }
  
