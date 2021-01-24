    public class Program
    {
	
	    public static HashSet<string> _hs = new HashSet<String>(Enumerable.Range(1,1000).Select(x=> "Item " + x));
	    public static string[] _arr = Enumerable.Range(1,1000).Select(x=> "Item " + x).ToArray();
		
	    public static void Main()
	    {
		
		    var sw = new Stopwatch();
		    sw.Start();
		    bool f;
		    for (int i = 1; i < 1001; i++)
		    {
		        //f = _hs.Contains("Item " + i, StringComparer.OrdinalIgnoreCase);
			    f = _arr.Contains("Item " + i, StringComparer.OrdinalIgnoreCase);
			
		    }
		    Console.WriteLine(sw.Elapsed);
		
		    sw.Restart();
		    for (int i = 1; i < 1001; i++)
		    {
		        f = _hs.Any(w => string.Equals(w, "Item " + i, StringComparison.InvariantCultureIgnoreCase));
		    }
		    Console.WriteLine(sw.Elapsed);
		
	    }
    }
