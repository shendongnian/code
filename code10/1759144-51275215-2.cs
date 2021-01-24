    public class MyHostedService : IHostedService
    {
         public MyHostedService(
              NotificationService notificationService)
         {
              // TODO get reference to sqlDependency
              sqlDependency.OnChange += (s, e) => _notificationService.SendMessage(e.Info.ToString());
         }         
    }
