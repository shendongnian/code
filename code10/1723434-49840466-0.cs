    public class Program
    {
    	static Stack<string> Proxies = new Stack<string>();
    	static List<string> lst = new List<string>{"a","b","c"};
    	
    	public static void Main()
    	{
    		loadStack();
    		Console.WriteLine(Proxies.Count);
    	}
    	
    	private static void loadStack()
        {
            foreach (string s in lst)
            {
                Proxies.Push(s);
                Console.WriteLine(Proxies.Count);
            }
        } 
    }
