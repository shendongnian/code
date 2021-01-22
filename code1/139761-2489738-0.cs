    class UpgradingStream : Stream
    {
      // state pattern lives in the problem...
      private abstract class InternalState
      {
        private readonly Stream _underlyingStream;
    
        protected InternalState(Stream underlyingStream)
        {
          _underlyingStream = underlyingStream;
        }
    
        internal Stream GetUnderlyingStream()
        {
          return _underlyingStream;
        }
    
        // template method lives in the implementation of this state pattern
        internal InternalState Seek(long offset, SeekOrigin origin, out long result)
        {
          result = _underlyingStream.Seek(offset, origin);
    
          return GetNextState();
        }
    
        internal InternalState SetPosition(long value)
        {
          _underlyingStream.Position = value;
    
          return GetNextState();
        }
    
        internal InternalState SetLength(long value)
        {
          _underlyingStream.SetLength(value);
    
          return GetNextState();
        }
    
        internal InternalState Write(byte[] buffer, int offset, int count)
        {
          _underlyingStream.Write(buffer, offset, count);
    
          return GetNextState();
        }
    
        protected abstract InternalState GetNextState();
      }
    
      private class InMemoryOnly : InternalState
      {
        private readonly Func<Stream> _getUpgradedStream;
        private readonly int _threshold;
    
        private InMemoryOnly(int threshold, Func<Stream> getUpgradedStream)
          : base(new MemoryStream(threshold))
        {
          _threshold = threshold;
          _getUpgradedStream = getUpgradedStream;
        }
    
        internal static InternalState GetInstance(int threshold, Func<Stream> getUpgradedStream)
        {
          return new InMemoryOnly(threshold, getUpgradedStream);
        }
    
        protected override InternalState GetNextState()
        {
          if (GetUnderlyingStream().Length > _threshold)
          {
            var newStream = _getUpgradedStream();
    
            CopyStream(newStream);
    
            return Unrestricted.GetInstance(newStream);
          }
    
          return this;
        }
    
        private void CopyStream(Stream newStream)
        {
          var originalPosition = GetUnderlyingStream().Position;
    
          GetUnderlyingStream().Position = 0;
    
          int bytesRead;
    
          var buffer = new byte[65536];
    
          while ((bytesRead = GetUnderlyingStream().Read(buffer, 0, buffer.Length)) != 0)
          {
            newStream.Write(buffer, 0, bytesRead);
          }
    
          newStream.Position = originalPosition;
        }
      }
    
      private class Unrestricted : InternalState
      {
        private Unrestricted(Stream underlyingStream)
          : base(underlyingStream)
        {
        }
    
        internal static Unrestricted GetInstance(Stream stream)
        {
          return new Unrestricted(stream);
        }
    
        protected override InternalState GetNextState()
        {
          // state never changes once we are in a file or whatever
          return this;
        }
      }
    
      private InternalState _state;
    
      private UpgradingStream(int threshold, Func<Stream> getMoreEfficientStream)
      {
        _state = InMemoryOnly.GetInstance(threshold, getMoreEfficientStream);
      }
    
      internal static Stream GetInstance(int threshold, Func<Stream> getMoreEfficientStream)
      {
        return new UpgradingStream(threshold, getMoreEfficientStream);
      }
    
      public override bool CanRead
      {
        get { return _state.GetUnderlyingStream().CanRead; }
      }
    
      public override bool CanSeek
      {
        get { return _state.GetUnderlyingStream().CanSeek; }
      }
    
      public override bool CanWrite
      {
        get { return _state.GetUnderlyingStream().CanWrite; }
      }
    
      public override void Flush()
      {
        _state.GetUnderlyingStream().Flush();
      }
    
      public override long Length
      {
        get { return _state.GetUnderlyingStream().Length; }
      }
    
      public override long Position
      {
        get
        {
          return _state.GetUnderlyingStream().Position;
        }
        set
        {
          _state = _state.SetPosition(value);
        }
      }
    
      public override int Read(byte[] buffer, int offset, int count)
      {
        return _state.GetUnderlyingStream().Read(buffer, offset, count);
      }
    
      public override long Seek(long offset, SeekOrigin origin)
      {
        long result;
    
        _state = _state.Seek(offset, origin, out result);
    
        return result;
      }
    
      public override void SetLength(long value)
      {
        _state = _state.SetLength(value);
      }
    
      public override void Write(byte[] buffer, int offset, int count)
      {
        _state = _state.Write(buffer, offset, count);
      }
    
      public override void Close()
      {
        _state.GetUnderlyingStream().Close();
      }
    }
