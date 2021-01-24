    public class CountryData : INotifyPropertyChanged
    {
        private string countryName;
        public string CountryName
        {
            get { return countryName; }
            set
            {
                countryName = value;
                RaisePropertyChanged("CountryName");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
       
    }
