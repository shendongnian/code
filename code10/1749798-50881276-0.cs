    public class MyClass : INotifyPropertyChanged
    {
        private string name;
        private string surname;
        private int age;
    
        public string HeyName
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged("HeyName");
            }
        }
    
        public string HeySurname
        {
            get => surname;
            set
            {
                surname = value;
                RaisePropertyChanged("HeySurname");
            }
        }
    
        public int HeyAge
        {
            get => age;
            set
            {
                age = value;
                RaisePropertyChanged("HeyAge");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
