    public class Your_Class: INotifyPropertyChanged
    {
       private string _destinationCode ;
       public string DestinationCode 
            {
                get
                {
                    return _destinationCode ;
                }
                set
                {
                    _destinationCode = value;
                    RaisePropertyChanged("DestinationCode ");
                }
            }
       public OperatingMode My_Enum {get;set;}
    
       public event PropertyChangedEventHandler PropertyChanged;
       protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    }
