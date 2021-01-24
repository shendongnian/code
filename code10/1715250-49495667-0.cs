    namespace app.Notifications
    {
        public class PasswordReset : INotification
        {
            private ISender _emailer;
    
            public PasswordReset(ISender emailer)
            {
                _emailer = emailer;
            }
        ...
    }
