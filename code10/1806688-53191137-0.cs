	public static void Main()
	{
		var collection = new ObservableCollection<string>(new [] { "a", "b" });
		var o = (object)collection;
		var eventInfo = o.GetType().GetEvent("CollectionChanged");
		var myEventHandler = new Action<object, NotifyCollectionChangedEventArgs>(( s, a ) => Console.WriteLine(a));
		var del = Delegate.CreateDelegate(eventInfo.EventHandlerType, myEventHandler.Method);
		eventInfo.AddEventHandler(o, del);
		collection.Add( "x" );
	}
