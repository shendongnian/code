    public class Split : Benchmark<string, Dictionary<string,int>>
    {
       protected override Dictionary<string,int> InternalRun()
       {
          return Input.Trim('{', '}')
                           .Split(',')
                           .Select(x => x.Split('='))
                           .ToDictionary(x => x[0], x => int.Parse(x[1]));
       }
    }
