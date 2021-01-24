	void Main()
	{
		var foo = new Foo();
		
		IObservable<EventPattern<EventArgs>> bar =
			Observable
				.FromEventPattern<EventHandler, EventArgs>(
					h => foo.Bar += h,
					h => foo.Bar -= h);
		
		IDisposable subscription = SimpleAttach(bar);
		SimpleDetach(subscription);
		
		foo.OnBar();		
	}
	
	public IDisposable SimpleAttach(IObservable<EventPattern<EventArgs>> example)
	{
		return example.Subscribe(x => Console.WriteLine("Bar!"));
	}
	
	public void SimpleDetach(IDisposable subscription)
	{
		subscription.Dispose();
	}	
	
	public class Foo
	{
		public event EventHandler Bar;
		public void OnBar()
		{
			this.Bar?.Invoke(this, new EventArgs());
		}
	}
