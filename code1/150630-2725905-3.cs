		public void WriteFoo(string comment)
		{
			if (_isDisposed)
				throw new ObjectDisposedException("MyWriter");
			
			// logic omitted
		}
