    public static IEnumerable<string> ToCSV(IEnumerable<double[]> source)
    {
        return source.Select(row => string.Join(",",
           Array.ConvertAll(row, x=>x.ToString())));        
    }
