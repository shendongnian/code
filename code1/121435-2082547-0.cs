      public class Wrapper: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            private bool val = false;
    
            public bool Val
            {
                get { return val; }
                set
                {
                    val = value;
                    this.OnPropertyChanged("Val");
                }
            }
    
            public Wrapper(bool val)
            {
                this.val = val;
            }
    
        }
