    public class MyItem
    {
        public DateTime { get; set; }
    }
    public class MyItemViewModel : INotifyPropertyChanged
    {
        private string relativeTime;
        public string RelativeTime
        {
            get { return relativeTime; }
            set
            {
                relativeTime = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("RelativeTime"));
            }
        }
        public DateTime Date { get; set; }
        public static implicit operator MyItemViewModel(MyItem item)
        {
            return new MyItemViewModel { Date = item.Date }
        }
    }
