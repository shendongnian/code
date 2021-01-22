    public class Page : INotifyPropertyChanged
    {
        private bool areNotificationsSuppressed;
    
        public IDisposable SuppressNotifications()
        {
            return new NotificationSuppression();
        }
    
        protected virtual void OnPropertyChanged(...)
        {
            if (this.areNotificationsSuppressed)
            {
                return;
            }
    
            ...
        }
    
        private sealed class NotificationSuppression : IDisposable
        {
            // set areNotificationsSuppressed to true, and then false once disposed
            // queue up any notifications and fire them after disposal
        }
    }
