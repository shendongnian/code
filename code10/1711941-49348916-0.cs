	class ImageDetectionStream : Stream
	{
		public string Mime { get; private set; }
		private readonly Stream _stream;
		private readonly byte[] _consideredBytes = new byte[MaxMagicNumberSize];
		private int _consideredPosition;
		private static readonly IDictionary<byte[], string> Magics = new Dictionary<byte[], string>
		{
			[new byte[] { 0xff, 0xdb, 0xff, 0xdb }] = "image/jpeg",
			[new byte[] { 0xff, 0xd8, 0xff, 0xe0 }] = "image/jpeg",
			[new byte[] { 0xff, 0xd8, 0xff, 0xe1 }] = "image/jpeg",
			// and so on... 
		};
		private static readonly int MaxMagicNumberSize = Magics.Keys.Max(x => x.Length);
		public ImageDetectionStream(Stream stream)
		{
			_stream = stream ?? throw new ArgumentNullException(nameof(stream));
		}
		public override int Read(byte[] buffer, int offset, int count)
		{
			var value = _stream.Read(buffer, offset, count);
			if (Mime != null) return value;
			Array.Copy(buffer, 0, _consideredBytes, 0, _consideredBytes.Length);
			_consideredPosition += value;
			if (_consideredPosition < MaxMagicNumberSize) return value;
			foreach (var magic in Magics)
			{
				var possibleMagic = buffer.Take(magic.Key.Length).ToArray();
				if (possibleMagic.SequenceEqual(magic.Key))
				{
					Mime = magic.Value;
					break;
				}
			}
			return value;
		}
        // boilerplate
		public override void Flush()
		{
			_stream.Flush();
		}
		public override long Seek(long offset, SeekOrigin origin)
		{
			return _stream.Seek(offset, origin);
		}
		public override void SetLength(long value)
		{
			_stream.SetLength(value);
		}
		public override void Write(byte[] buffer, int offset, int count)
		{
			_stream.Write(buffer, offset, count);
		}
		public override bool CanRead => _stream.CanRead;
		public override bool CanSeek => _stream.CanSeek;
		public override bool CanWrite => _stream.CanWrite;
		public override long Length => _stream.Length;
		public override long Position
		{
			get => _stream.Position;
			set => _stream.Position = value;
		}
	}
