    public class Regex : Benchmark<string, Dictionary<string,int>>
    {
       protected override Dictionary<string,int> InternalRun()
       {
          var regex = new System.Text.RegularExpressions.Regex("(?<key>[^,]+)=(?<value>[^,]+)");
          var matchCollection = regex.Matches(Input.Trim('{', '}'));
          return matchCollection.Cast<Match>()
                         .ToDictionary(
                             x => x.Groups["key"].Value,
                             x => int.Parse(x.Groups["value"].Value));
       }
    }
