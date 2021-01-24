	private Action<MyObject3> _delegate;
	
	private void SetUpObservable()
	{
		Observable
			.FromEvent<MyObject3>(h => _delegate += h, h => _delegate -= h)
			.Subscribe(x => Console.WriteLine($"Message acknowledged"));
	}
	
	public virtual void MessageHandler(MyObject1 object1, MyObject2 object2)
	{
		_delegate?.Invoke(new MyObject3(object1, object2));
	}
