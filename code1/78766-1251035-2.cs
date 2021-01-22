    public static class MatchMaker
    {
    	public class Source
    	{
    		char Term { get; set; }
    		IEnumerable<string> Results { get; set; }
    	}
    
    	public static IEnumerable<Source> Match(IEnumerable<string> source, IEnumerable<string> target)
    	{
    		int currentIndex = 0;
    		var matches = from term in source
    					  select new Source
    					  {
    						  Term = term[0],
    						  Result = from result in target.FromIndex(currentIndex)
    									   .TakeWhile((r, i) => {
    										   currentIndex = i;
    										   return r[0] == term[0];
    									   })
    								   select result
    					  };
    	}
    	public static IEnumerable<T> FromIndex<T>(this IList<T> subject, int index)
    	{
    		while (index < subject.Count) {
    			yield return subject[index++];
    		}
    	}
    }
