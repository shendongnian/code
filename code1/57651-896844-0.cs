    using System.Text.RegularExpressions;
    
    public static MatchCollection getMatches(String input, String pattern) {
       Regex re = new Regex(pattern);
       return re.Matches(input);
    }
    
    public static void Example() {
       String pattern1 = "var matches = new Array\\(([^\\)]+)\\)";
    
       MatchCollection results = getMatches(RandomTest, pattern1);
       String marray = results[0].Groups[1].Value;
       String pattern2 = "\"([^\"]+)\"";
       List<String> values = new List<String>();
       foreach (Match value in getMatches(marray,pattern2)) {
          //Your values are in the Groups property
          values.Add(value.Groups[1].Value);
          Console.WriteLine(value.Groups[1].Value);
       }
    }
