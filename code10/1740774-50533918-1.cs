	public class SendIntMessages : IObservable<int>
	{
		private readonly HashSet<IObserver<int>> _observers = new HashSet<IObserver<int>>();
		
		protected void OnNext(int i)
		{
			foreach (var o in _observers)
				o.OnNext(i);
		}
	
		protected void OnError(Exception e)
		{
			foreach (var o in _observers)
				o.OnError(e);
		}
	
		protected void OnCompleted()
		{
			foreach (var o in _observers)
				o.OnCompleted();
		}
	
		public void SendIntMessage(int i)
		{
			OnNext(i);
		}
		
		public void EndStream()
		{
			OnCompleted();
		}
		
		public void SendError(Exception e)
		{
			OnError(e);
		}
		
		public IDisposable Subscribe(IObserver<int> observer)
		{
			_observers.Add(observer);
			return GenericDisposable.Create(() => _observers.Remove(observer));
		}
	}
