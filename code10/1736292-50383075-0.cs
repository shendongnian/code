    public class MasterVM 
        {
            public ServerVM Server { get; set; }
        }
    
        public class ServerVM : INotifyPropertyChanged
    
        {
            private string serverName;
            public string ServerName {
                get
                {
                    return serverName;
                }
                set
                {
                    serverName = value;
                    OnPropertyChanged("ServerName");        
                }
    
            }
    
            private void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
