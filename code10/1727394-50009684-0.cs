        class Person : INotifyPropertyChanged
        {
            private string name;
            public string Name 
            { 
              get
              {
                 return name;
              } 
              set
              {
                  if(value != name)
                  {
                      name = value;
                      RaisePropertyChange("Name");
                  }
              }
            }
              
              public event PropertyChangedEventHandler PropertyChanged;
    
              public void RaisePropertyChange(string propertyname) 
              {  
                 if (PropertyChanged != null) 
                 {  
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));  
                 }  
              }
        }
