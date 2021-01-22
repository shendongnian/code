    public interface IInterface
    {
    	int X { get; set; }
    	int Y { get; set; }
    }
    
    public static class IInterfaceTHelper
    {
    	public static IInterface Add<T>(this IInterface a, IInterface b) 
    		where T : new()
    	{
        	var ret = (IInterface)new T();
    		ret.X = a.X + b.X;
    		ret.Y = a.Y + b.Y;
    		return ret;
    	}
    }
    
    class Foo : IInterface
    {
    	public int X { get; set; }
    	public int Y { get; set; }
    
    	public static IInterface operator +(Foo a, IInterface b)
    	{
    		return a.Add<Foo>(b);
    	}
    }
    
    class Bar : IInterface
    {
    	public int X { get; set; }
    	public int Y { get; set; }
    
    	public static IInterface operator +(Bar a, IInterface b)
    	{
    		return a.Add<Bar>(b);
    	}
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		var foo = new Foo { X = 5, Y = 3 };
    		var bar = new Bar { X = 3, Y = 5 };
    
            var result = foo + bar;
	        Console.WriteLine(result.GetType().Name + " " + result.X + " " + result.Y);
    		result = bar + foo;
    		Console.WriteLine(result.GetType().Name + " " + result.X + " " + result.Y);
    
    		Console.ReadLine();
    	}
    }
