    DateTime LastMsgTime = DateTime.MinValue;
    Timer timer = new Timer { Interval = 50, Enabled = false };
    timer.Tick += (s,e) => 
    { 
        if((DateTime.Now- LastMsgTime).TotalMilliSeconds > 500)  
           {ExampleMethod(); timer.Enabled = false; }
    };
    while (await streamingCall.ResponseStream.MoveNext(
                        default(CancellationToken)))
                    {
                         LastMsgTime = DateTime.Now;
                        //Message received
                        timer.Enabled = true;
                    }
