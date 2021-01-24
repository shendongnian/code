    public class MarketDescription : INotifyPropertyChanged
    {
        // implements your interface here
        ...
        // your property to bind
        private DateTime suspendTime;
        public DateTime SuspendTime
        {
            get { return suspendTime; }
            set 
            {
                suspendTime = value;
                NotifyPropertyChanged("SuspendTime");
            }
        }
    }
