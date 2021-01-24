    public class Dictionary : Benchmark<List<string>, List<string>>
    {
    
        public static IEnumerable<string> GetDistinctDuplicates(IEnumerable<string> original)
        {
           var dict = new Dictionary<string, bool>();
           foreach (var s in original)
              if (dict.TryGetValue(s, out var isReturnedDupl))
              {
                 if (isReturnedDupl)
                    continue;
        
                 dict[s] = true;
                 yield return s;
              }
              else
                 dict.Add(s, false);
        }
        protected override List<string> InternalRun()
        {
           return GetDistinctDuplicates(Input).ToList();
        }
    
    }
