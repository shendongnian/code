    ...
    private byte[] buffer;
    private Queue<TraceItem> queue;
    public void Process() {
      queue = new Queue<TraceItem>(batch);
      while (connected) {
        ReceiveMessage();
        TryProcessMessage();
      }
    }
    private void ReceiveMessage() {
      try {
        socket.Recv(out buffer);
      }
      catch {
        // ignore the exception we get when the socket is shut down from another thread
        // the connected flag will be set to false and we'll break the processing
      }
    }
    private void TryProcessMessage() {
      try {
        ProcessMessage();
      }
      catch (Exception ex) {
        ProcessError(ex);
      }
    }
    private void ProcessError(Exception ex) {
      ReceiverPerformanceCounter.IncrementDiagnosticExceptions();
      tracer.TraceException(TraceEventType.Error, 0, ex);
    }
    private void ProcessMessage() {
      if (buffer == null) return;
      var item = TraceItemSerializer.FromBytes(buffer);
      if (item == null) return;
      queue.Enqueue(item);
      if (HasMoreData()) {
        TryProcessMessage();
      }
    }
    private bool HasMoreData() {
      return queue.Count < batch && socket.Recv(out buffer, ZMQ.NOBLOCK);
    }
    ...
