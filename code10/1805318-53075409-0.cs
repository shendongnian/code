    public class Data : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public object this[string field]
        {
            get => // gets the value
            set
            {
                // sets the value
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
            }
        }
        public object some_field => this[nameof(some_field)];
        public object some_other_field=> this[nameof(some_other_field)];
    }
