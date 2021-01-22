    public override IAsyncResult BeginRead (byte[] buffer, int offset, int count, AsyncCallback cback, object state)
    {
      _outBuff = buffer;
      if ( _in.IsNeedingInput )
        return _innerStream.BeginRead(_inBuff, 0, _inBuff.Length, cback, state);
        
      ZlibStreamAsyncResult ar = new ZlibStreamAsyncResult(state);
      cback(ar);
      return ar;
    }
