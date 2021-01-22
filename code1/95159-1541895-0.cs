	class ReaderWriterQueue<T>
	{
		readonly AutoResetEvent _readComplete;
		readonly T[] _buffer;
		readonly int _maxBuffer;
		int _readerPos, _writerPos;
		
		public ReaderWriterQueue(int maxBuffer)
		{
			_readComplete = new AutoResetEvent(true);
			_maxBuffer = maxBuffer;
			_buffer = new T[_maxBuffer];
			_readerPos = _writerPos = 0;
		}
		public int Next(int current) { return ++current == _maxBuffer ? 0 : current; }
		public bool Read(ref T item)
		{
			if (_readerPos != _writerPos)
			{
				item = _buffer[_readerPos];
				_readerPos = Next(_readerPos);
				return true;
			}
			else
				return false;
		}
		public void Write(T item)
		{
			int next = Next(_writerPos);
			while (next == _readerPos)
				_readComplete.WaitOne();
			_buffer[next] = item;
			_writerPos = next;
		}
	}
