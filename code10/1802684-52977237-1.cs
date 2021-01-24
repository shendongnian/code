    public class Program
    {
	
	 public static void Main()
	 {
		var dict = new Dictionary<string, object>{
			{"test1", true},
			{"test2", 2}
		};
		
		var result = dict.GetDictionaryItemValueOrDefault<bool?>("test1");
		Console.WriteLine(result.ToString());
	 }
    }
    public static class Extensions{
     public static T GetDictionaryItemValueOrDefault<T>(this Dictionary<string, object> dictionary, string key){	
		if(!dictionary.TryGetValue(key, out var result) || !(result is T))
		   return default(T);
		return (T)result;
	 }	
    }
