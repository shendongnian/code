    class MyDataSouce : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
        private bool enabled=true, visible=true;
    
        public bool Enabled {
            get { return enabled; }
            set {
                enabled= value;
                PropertyChanged(this, new PropertyChangedEventArgs("Enabled"));
            }
    
        }
    
        public bool Visible {
            get { return visible; }
            set {
                visible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Visible"));
            }
        }
    }
