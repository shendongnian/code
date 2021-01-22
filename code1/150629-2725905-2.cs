	public sealed class MyWriter : IDisposable
	{
		private System.IO.FileStream _fileStream;
		private bool _isDisposed;
		public MyWriter(string path)
		{
			_fileStream = System.IO.File.Create(path);
		}
	#if DEBUG
		~MyWriter() // Finalizer for DEBUG builds only
		{
			Dispose(false);
		}
	#endif
		public void Close()
		{
			((IDisposable)this).Dispose();
		}
		private void Dispose(bool disposing)
		{
			if (disposing && !_isDisposed)
			{
				// called from IDisposable.Dispose()
				if (_fileStream != null)
					_fileStream.Dispose();
				_isDisposed = true;
			}
			else
			{
				// called from finalizer in a DEBUG build.
				// Log so a developer can fix.
				Console.WriteLine("MyWriter failed to be disposed");
			}
		}
		void IDisposable.Dispose()
		{
			Dispose(true);
	#if DEBUG
			GC.SuppressFinalize(this);
	#endif
		}
	}
