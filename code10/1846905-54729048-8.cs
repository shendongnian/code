	void Main()
	{
		var foo = new Foo();
		
		foo.Bar += (s, e) => Console.WriteLine("Bar!");
		foo.Bar -= (s, e) => Console.WriteLine("Bar!");
		
		foo.OnBar();
	}
	
	public class Foo
	{
		public event EventHandler Bar;
		public void OnBar()
		{
			this.Bar?.Invoke(this, new EventArgs());
		}
	}
