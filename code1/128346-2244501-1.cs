	// ignore threadsafety and performance issues for now.
	private Dictionary<string, EventHandler> _Events;
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
