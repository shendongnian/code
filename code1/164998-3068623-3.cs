    public class Client
    {
        private readonly INotificationsService _notificationsService;
    
        [Import(typeof(INotificationService), 
            RequiredCreationPolicy = CreationPolicy.NonShared)]
        public INotificationsService NotificationsService
        {
            get
            {
                return _notificationsService;
            }
            set
            {
               _notificationsService = value;
               _notificationsService.ID = "SomeID"; 
            }
        }
    }
