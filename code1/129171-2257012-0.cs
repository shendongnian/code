    public class YourClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }
        public bool isRead;
        [DisplayName("Read")]
        public bool IsRead
        {
            get { return isRead; }
            set { isRead = value; OnPropertyChanged("IsRead"); }
        }
    }
