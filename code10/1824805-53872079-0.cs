    class Generator<T>
    {
    	event Action<T> onPush;
    	event Action<Unit> onCompleted;
    
    	public IObservable<T> Items =>
    		Observable.FromEvent<T>(d => onPush += d, d => onPush -= d)
    		.TakeUntil(Completion);
    
    	public IObservable<Unit> Completion =>
    		Observable.FromEvent<Unit>(d => onCompleted += d, d => onCompleted -= d);
    		
    	public void Push(T item) => onPush?.Invoke(item);
    	public void Complete() => onCompleted?.Invoke(Unit.Default);
    }
