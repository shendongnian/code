	// ignore threadsafety and performance issues for now.
	private Dictionary<string, List<EventHandler<PositionChangedEventArgs>>> _Events;
	private void AddId (string id)
	{
		_Events[id] = new List<EventHandler<PositionChangedEventArgs>> ();
	}
	public void Subscribe (string id, EventHandler<PositionChangedEventArgs> handler)
	{
		_Events[id].Add (handler);
	}
	public void Unsubscribe (string id, EventHandler<PositionChangedEventArgs> handler)
	{
		_Events[id].Remove (handler);
	}
	private void Raise (string id)
	{
		PositionChangedEventArgs args = null;
		foreach (var handler in _Events[id]) {
			handler (this, args);
		}
	}
