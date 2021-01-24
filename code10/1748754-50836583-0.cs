    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Department { get; set; }
        public string Level { get; set; }
        public Gender Gender { get; set; }
        
        private string _nationality;
        public string Nationality 
        { 
            get
            {
                return _nationality;
            }  
            set
            {
                if(value != _nationality)
                {
                    _nationality = value;
                    OnPropertyChanged(nameof(Nationality));
                }
             } 
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
