    public class Foo
    {
    	public ICollection<string> Bar { get; } = new List<string>();
    }
	var foo = new Foo
	{
		Bar = { new [] { "foo", "bar", "baz" } }
	};
		
