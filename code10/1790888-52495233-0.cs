    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Infrastructure;
    using Microsoft.AspNet.Mvc;
    
    public class TestController : Controller
    {
         private IHubContext testHub;
    
         public TestController(IConnectionManager connectionManager)
         {
             testHub = connectionManager.GetHubContext<TestHub>();
             testHub.Clients.All.SendnewData(Data);
         }
    }
 
