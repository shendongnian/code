    public class ViewModel : INotifyPropertyChanged
    {
        private string tipodoc;
        public string TipoDoc
        {
            get => tipodoc;
            set
            {
                tipodoc = value;
                RaisePropertyChanged("TipoDoc");
            }
        }
        public ObservableCollection<string> source { get; set; }
        public ViewModel()
        {
            source = new ObservableCollection<string>();
            source.Add("item1");
            source.Add("item2");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged!= null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
