    public class MyService : ServiceBase
    {
     private int id;
    
     public override OnStart()
     {
       id = GetIdFOrProcess("someidentifier");
       .....
     }
    
     public override OnStop()
     {
      UpdateServiceStopTime(id);
      .....
     }
    }
