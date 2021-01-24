	public class Y
	{
		private readonly Subject<int> _subject = new Subject<int>();
		public Y()
		{
			IntObservable = _subject.AsObservable();
		}
	
		private int OnCallback(string Arr, int Len)
		{
			//do something
			var intValue = 0;
			_subject.OnNext(intValue);
			return intValue;
		}
		public IObservable<int> IntObservable { get; } 
	
	}
