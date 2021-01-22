    public class MyServiceClient : IMyService
    {
      public MyServiceClient(IChannelFactory<IMyService> channel)
      {
      }
    
      public void DoSomething() //DoSomething is the implementation of IMyService
      {
         //Initialize the behavior in the channel
         //Calls channel.DoSomething
      }
    }
