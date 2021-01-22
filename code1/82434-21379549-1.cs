    public class Dog : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                this.SetPropertyAndNotify(PropertyChanged, ref _name, value);
            }
        }
    }
