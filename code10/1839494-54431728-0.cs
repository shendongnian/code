    private ConcurrentQueue<Command> _queue = new ConcurrentQueue<Command>();
    //wherever your start point it
    void Main()
    {
        Task.Run(()=> ProcessAsync());
    }
    async Task ProcessAsync()
    {
        while(true)
        {
           if(_queue.TryDequeue(out var command))
           {
              
               switch(command.Action)
               {
                  case "flash" : FlashLight(command.Device); break;
                  case "steady" : SteadyLight(command.Device); break;
               }
               // wait for duration to end, then we switch off the device
               await Task.Delay(command.Duration * 1000);
               LightOff(command.Device);
           }
        }
    }
    public void CommandReceived(string device, string action, int duration)
    {
        _queue.Enqueue(new Command { Device = device, Action = action, Duration = duration});
    }
    public class Command
    {
        public string Device {get;set;}
        public string Action {get;set;}
        public int Duration {get;set;}
    }
    
