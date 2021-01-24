    static void Main(string[] args) {
        //...
        channel.BasicConsume(exchangeAndQueue2, autoAck: false, consumer: consumer);
        Trace.TraceInformation("Application started. Press Ctrl+C to shut down.");
        var exitEvent = new AutoResetEvent(false);
        Console.CancelKeyPress += (s, e) => { e.Cancel = true; exitEvent.Set(); };
        exitEvent.WaitOne();
        Trace.TraceInformation("Ctrl+C pressed.");
        mq.CloseConnection();
    }
     
