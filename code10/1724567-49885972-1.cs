    public static List<MovieInfo> processData(IEnumerable<string> lines)
    {
        if (lines == null) return null;
        var results = new List<MovieInfo>();
        foreach (var line in lines)
        {
            MovieInfo temp;
            if (MovieInfo.TryParse(line, out temp))
            {
                results.Add(temp);
            }
        }
        var maxVersion = results.Max(result => result.Version);
        return results.Where(result => result.Version == maxVersion).ToList();
    }
