	public class CountTo5 : IObservable<int>
	{
		public IDisposable Subscribe(IObserver<int> observer)
		{
			observer.OnNext(1);
			observer.OnNext(2);
			observer.OnNext(3);
			observer.OnNext(4);
			observer.OnNext(5);
			return GenericDisposable.Create(() => {});
		}
	}
