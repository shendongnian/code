	// ignore threadsafety and performance issues for now.
	private Dictionary<string, EventHandler> _Events = new Dictionary<string, EventHandler> ();
	private void AddId (string id)
	{
		_Events[id] = delegate {
		};
	}
	public void Subscribe (string id, EventHandler handler)
	{
		_Events[id] += handler;
	}
	public void Unsubscribe (string id, EventHandler handler)
	{
		_Events[id] -= handler;
	}
	private void Raise (string id)
	{
		_Events[id] (this, new EventArgs ());
	}
	static void Main (string[] args)
	{
		var p = new Program ();
		p.AddId ("foo");
		p.Subscribe ("foo", (s, e) => Console.WriteLine ("foo"));
		p.Raise ("foo");
		p.AddId ("bar");
		p.Subscribe ("bar", (s, e) => Console.WriteLine ("bar 1"));
		p.Subscribe ("bar", (s, e) => Console.WriteLine ("bar 2"));
		p.Raise ("bar");
		Console.ReadKey ();
	}
