    class Program
    {
    	static void Main()
    	{
    		var foo1 = new Foo
    		{
    			Bar =
    			{
    				"one",
    				"two"
    			}
    		};
    
    		var foo2 = new Foo
    		{
    			Bar =
    			{
    				"three",
    				"four"
    			}
    		};
    
    		PrintList(foo1.Bar);
    	}
    
    	public static void PrintList(List<string> list)
    	{
    		foreach (var item in list)
    		{
    			Console.Write(item + ", ");
    		}
    		Console.WriteLine();
    	}
    
    }
    
    public class Foo
    {
    	private static readonly List<string> _bar = new List<string>();
    	public List<string> Bar { get; private set; } = _bar;
    }
