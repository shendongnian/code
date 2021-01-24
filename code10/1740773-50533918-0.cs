	public class GenericDisposable : IDisposable
	{
		public static IDisposable Create(Action disposeAction)
		{
			return new GenericDisposable(disposeAction);
		}
		
		private readonly Action _disposeAction;
		public GenericDisposable(Action disposeAction)
		{
			_disposeAction = disposeAction;
		}
		public void Dispose()
		{
			_disposeAction();
		}
	}
