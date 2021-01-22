	public class AppendingStream : Stream
	{
		private readonly long _startPos;
		private readonly Stream _sink;
		public AppendingStream(Stream sink)
		{
			if(sink == null)
				throw new ArgumentNullException();
			if(!sink.CanWrite)
				throw new ArgumentException();
			_sink = sink;
			try
			{
				_startPos = sink.Position;
			}
			catch(NotSupportedException)
			{
				_startPos = -1;
			}
		}
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}
		public override bool CanSeek
		{
			get
			{
				return _sink.CanSeek && _startPos != -1;
			}
		}
		public override bool CanTimeout
		{
			get
			{
				return _sink.CanTimeout;
			}
		}
		public override bool CanWrite
		{
			get
			{
				return true;
			}
		}
		public override long Length
		{
			get
			{
				if(_startPos == -1)
					throw new NotSupportedException();
				return _sink.Length - _startPos;
			}
		}
		public override long Position
		{
			get
			{
				return _sink.Position - _startPos;
			}
			set
			{
				_sink.Position = value + _startPos;
			}
		}
		public override void Flush()
		{
			_sink.Flush();
		}
		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}
		public override int ReadByte()
		{
			throw new NotSupportedException();
		}
		public override long Seek(long offset, SeekOrigin origin)
		{
			if(origin == SeekOrigin.Begin)
				return _sink.Seek(offset + _startPos, SeekOrigin.Begin) - _startPos;
			else
				return _sink.Seek(offset, origin);
		}
		public override void SetLength(long value)
		{
			if(_startPos == -1)
				throw new NotSupportedException();
			_sink.SetLength(value + _startPos);
		}
		public override void Write(byte[] buffer, int offset, int count)
		{
			_sink.Write(buffer, offset, count);
		}
		public override void WriteByte(byte value)
		{
			_sink.WriteByte(value);
		}
	}
