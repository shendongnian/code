	var o = p.GetValue(this,null);
	EventInfo eventInfo = t.GetEvent("CollectionChanged", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
	var handler = new Action<object, NotifyCollectionChangedEventArgs>((s, a) => { Console.WriteLine("Changed + " + this.TestInt.ToString()); });
	
	Delegate del = Delegate.CreateDelegate(eventInfo.EventHandlerType, handler.Target, handler.Method);
	
	eventInfo.AddEventHandler(o, del);
