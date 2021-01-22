		public class DisposableFinalisableClass : IDisposable
		{
			~DisposableFinalisableClass()
			{
				Dispose(false);
			}
			public void Dispose()
			{
				Dispose(true);
			}
			protected virtual void Dispose(bool disposing)
			{
				if (disposing)
				{
					// tidy managed resources
				}
				// tidy unmanaged resources
			}
		}
