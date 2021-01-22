    // Pseudo-code.
    ArraySegment<byte> CheckOut()
    {
      ArraySegment<byte> result;
      while(!_queue.TryDequeue(out result))
        GrowBufferQueue(); //Enqueue a bunch more buffers.
      return result;
    }
    
    void CheckOut(ArraySegment<byte> buffer)
    {
      _queue.Enqueue(buffer);
    }
    void GrowBufferQueue()
    {
      // Verify this, I did throw it together in 30s.
      // Allocates nearly 2MB. You might want to tweak that.
      for(var j = 0; j < 5; j++)
      {
        var buffer = new byte[409600]; // 4096 = page size on Windows.
        for(var i = 0; i < 409600; i += 4096)
          _queue.Enqueue(new ArraySegment<byte>(buffer, i, 4096));
      }
    }
