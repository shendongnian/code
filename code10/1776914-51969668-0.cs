	public class X
	{
		public X()
		{
			AutoReadProc += OnCallback; //If still necessary.
			IntObservable = Observable.FromEvent<GIS_LF_API.AutoReadCallback, int>(h => AutoReadProc += h, h => AutoReadProc -= h);
		}
	
		public event GIS_LF_API.AutoReadCallback AutoReadProc;
		private int OnCallback(string Arr, int Len)
		{
			//do something, if necessary. Not required for observable.
			var intValue = 0;
			return intValue;
		}
		public IObservable<int> IntObservable { get; }
	
	}
