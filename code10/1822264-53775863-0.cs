    class Model
    {
        private string name;
        
        public string Name
        {
            get=>name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
