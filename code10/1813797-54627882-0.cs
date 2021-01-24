    private Poller _poller;
    public void Start()
    {
      Task.Factory.StartNew(()=> {
         using(var pullSocket = new PullSocket("tcp://ip1:port1"))
         using(_poller = new Poller())
         {
            pullSocket.ReceiveReady += (object sender, NetMQSocketEventArgsnetMqSocketEventArgs) =>
            {
                var message = netMqSocketEventArgs.Socket.ReceiveMultipartMessage();
            }
            _poller.Add(pullSocket);
            _poller.Run();
         }
        });
    }
    public void Stop()
    {
       _poller?.Stop();
    }
