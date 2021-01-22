	// variant delegate with variant event args
	MyEventHandler<<in T>(object sender, IMyEventArgs<T> a)
	// class implementing variant interface
	class FiresEvents<T> : IFiresEvents<T>
	{
		// list instead of event
		private readonly List<MyEventHandler<T>> happened = new List<MyEventHandler<T>>();
		// custom event implementation
		public event MyEventHandler<T> Happened
		{
			add
			{
				happened.Add(value);
			}
			remove
			{
				happened.Remove(value);
			}
		}
		public void Foo()
		{
			happened.ForEach(x => x.Invoke(this, new MyEventArgs<T>(t));
		}
	}
