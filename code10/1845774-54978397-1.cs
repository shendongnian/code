    public class SampleModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(PropertyName));
            }
        }
        private int _Id;
        public int Id
        {
            get => _Id;
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }
        private string _Description;
        public string Description
        {
            get =>_Description;
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }
        private SolidColorBrush _ItemBackground = new SolidColorBrush(Colors.Transparent);
        public SolidColorBrush ItemBackground
        {
            get => _ItemBackground;
            set
            {
                if (_ItemBackground !=value)
                {
                    _ItemBackground = value;
                    RaisePropertyChanged("ItemBackground");
                }
            }
        }
    }
