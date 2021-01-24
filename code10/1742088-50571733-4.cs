    public class ConnectionItem : INotifyPropertyChanged
      {
          public event PropertyChangedEventHandler PropertyChanged;
    
          public ConnectionItem(string name)
          {
              Name = name;
          }
    
          public string Name { get; }
    
          private string _color = "Red";
          public string Color
          {
              get => _color;
              set
              {
                  if (value == _color) return;
                  _color = value;
                  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
              }
          }
    
          private ConnectionStatus _status;
          public ConnectionStatus Status
          {
              get => _status;
              set
              {
                  if (value == _status) return;
                  _status = value;
                  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
                  switch (value)
                  {
                      case ConnectionStatus.Connected:
                          Color = "Yellow";
                          break;
                      case ConnectionStatus.Ready:
                          Color = "Green";
                          break;
                      default:
                          Color = "Red";
                          break;
                  }               
              }
          }
      }
