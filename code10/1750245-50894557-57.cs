    public class GroupBy2 : Benchmark<List<string>, List<string>>
    {
       protected override List<string> InternalRun()
       {
          return Input.GroupBy(x => x)
                      .Where(g => g.Count() > 1)
                      .Select(y => y.Key)
                      .ToList();
       }
    } 
