    var queue = new Queue<TraceItem>(this.batch);
    while (this.connected)
    {
        byte[] buffer = null;
        try
        {
            socket.Recv(out buffer);
        }
        catch
        {
            // ignore the exception we get when the socket is shut down from another thread
            // the connected flag will be set to false and we'll break the loop
        }
        bool hasAnotherMessage = true
        while(hasAnotherMessage)
        {
            hasAnotherMessage = false;
            if (buffer != null)
            {
                try
                {
                    var item = TraceItemSerializer.FromBytes(buffer);
                    if (item != null)
                    {
                        queue.Enqueue(item);
        
                        buffer = null;
                        if (queue.Count < this.batch && socket.Recv(out buffer, ZMQ.NOBLOCK))
                        {
                            hasAnotherMessage = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.ReceiverPerformanceCounter.IncrementDiagnosticExceptions();
                    this.tracer.TraceException(TraceEventType.Error, 0, ex);
                }
            }
        }
        // queue processing code
    }
