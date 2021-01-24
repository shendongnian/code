    public static List<Movies> processData(string s)
    {
        // list to store all movies
        List<Movies> allmovies = new List<Movies>();
    
        // first split by new line
        var splitbynewline = s.Split('\n');
        // split by ',' and initilize object
        foreach (var line in splitbynewline)
        {
            var moviestring = line.Split(',');
            // create new movie object
            Movies obj = new Movies { Name = moviestring[0], Author = moviestring[1], Version = moviestring[2] };
            obj.VersionNumber = extractNumberFromString(moviestring[2]);
            allmovies.Add(obj);
        }
    
        // get the max version number
        double maxver = allmovies.Max(x => x.VersionNumber);
        // set and returen list that containes all movies with max version
        List<Movies> result = allmovies.Where(x => x.VersionNumber == maxver).ToList();
    
        return result;
    }
    
    /// <summary>
    /// 
    /// convert number that exist in a string to an int32 for example sdfdf43gn will return as 43
    /// </summary>
    /// <param name="value">string that contains inside him as digits</param>
    /// <returns>int32</returns>
    public static double extractNumberFromString(string value)
    {
        string returnVal = string.Empty;
        System.Text.RegularExpressions.MatchCollection collection = System.Text.RegularExpressions.Regex.Matches(
        foreach (System.Text.RegularExpressions.Match m in collection)
        {
            returnVal += m.ToString();
        }
    
        return Convert.ToDouble(returnVal);
    }
    
    public class Movies
    {
        public string Name;
        public string Author;
        public string Version;
        public double VersionNumber;
    }
