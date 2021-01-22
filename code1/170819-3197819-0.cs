    while (queue.Count < this.batch && buffer != null)
    {
        try
        {
            var item = TraceItemSerializer.FromBytes(buffer);
            buffer = null;
            if (item != null)
            {
                queue.Enqueue(item);
                socket.Recv(out buffer, ZMQ.NOBLOCK)
            }
        }
        catch (Exception ex)
        {
            this.ReceiverPerformanceCounter.IncrementDiagnosticExceptions();
            this.tracer.TraceException(TraceEventType.Error, 0, ex);
        }
    }
