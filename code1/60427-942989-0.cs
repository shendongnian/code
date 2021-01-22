    public class Reminder : INotifyPropertyChanged
    {
        private string time;
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                if (this.time != value)
                {
                    this.time = value;
                    this.OnTimeChanged();
                }
            }
        }
        protected void OnTimeChanged()
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs("Time"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
