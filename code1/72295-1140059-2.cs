     public class Floor : INotifyPropertyChanged
            {
                private int _height;
    
                public int Height
                {
                    get { return _height; }
                    set 
                    {
                        if (HeightChanged != null)
                            HeightChanged(value, _height);
    
                        _height = value;
                        OnPropertyChanged("Height");
    
                    }
                }
    
    
    
    
                public int Elevation { get; set; }
    
                private void OnPropertyChanged(string property)
                {
                    if (this.PropertyChanged != null)
                        this.PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
    
                #region INotifyPropertyChanged Members
    
                public event PropertyChangedEventHandler PropertyChanged;
    
                #endregion
    
                public delegate void HeightChangedEventHandler(int newValue, int oldValue);
                public event HeightChangedEventHandler HeightChanged;
            }
