	private Subject<MyObject3> _subject = new Subject<MyObject3>();
	
	private void SetUpObservable()
	{
		_subject = new Subject<MyObject3>();
		_subject.Subscribe(x => Console.WriteLine($"Message acknowledged"));
	}
	
	public virtual void MessageHandler(MyObject1 object1, MyObject2 object2)
	{
		_subject.OnNext(new MyObject3(object1, object2));
	}
