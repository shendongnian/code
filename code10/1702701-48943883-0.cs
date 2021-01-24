    using System.Text.RegularExpressions;
    
    static void Main(string[] args)
    {
    
        string input = "bla absl ael   dls ale ";
    
        var result = Regex.Matches(input, " +");
    
        var result2 = Regex.Replace(input, " +", new MatchEvaluator(ReplaceByCount));
        Console.WriteLine(result2);
        //returns bla1absl1ael3dls1ale1
    }
    
    private static string ReplaceByCount(Match m)
    {
        return m.Value.Length.ToString();
    }
