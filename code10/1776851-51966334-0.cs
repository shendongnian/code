    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Infrastructure;
    using Microsoft.AspNet.Mvc;
    
    public class TestController : Controller
    {
         private IHubContext testHub;
    
         public TestController(IConnectionManager connectionManager)
         {
             //get connection manager using HubContext
             testHub = connectionManager.GetHubContext<TestHub>();
         }
    }
