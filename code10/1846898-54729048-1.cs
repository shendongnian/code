	void Main()
	{
		var foo = new Foo();
		IObservable<EventPattern<EventArgs>> bar =
			Observable
				.FromEventPattern<EventHandler, EventArgs>(
					h => foo.Bar += h,
					h => foo.Bar -= h);
	}
	
	public void SimpleExample(IObservable<EventPattern<EventArgs>> example)
	{
		example.Subscribe(x => { });
	}
	
	public class Foo
	{
		public event EventHandler Bar;
		public void OnBar()
		{
			this.Bar?.Invoke(this, new EventArgs());
		}
	}
