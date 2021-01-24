            public class VoltageViewModel : INotifyPropertyChanged {
        private List<Voltage>  _data;
         public List<Voltage> Data { 
    get{return _data;} 
    set{_data = value; NotifyPropertyChanged("Data");} }
    
     public VoltageViewModel() {
     Data = new List<Voltage>() { 
    new Voltage() { Timestamp = DateTime.Now.AddMinutes(-1), Value = 5.1 }, 
    new Voltage() { Timestamp = DateTime.Now.AddMinutes(-2), Value = 4.9 }, 
    new Voltage() { Timestamp = DateTime.Now.AddMinutes(-3), Value = 4.85 },
     new Voltage() { Timestamp = DateTime.Now.AddMinutes(-4), Value = 5.01 } 
    }; 
    } 
    
    public event PropertyChangedEventHandler PropertyChanged = delegate { }; 
    
    public void OnPropertyChanged([CallerMemberName] string propertyName = null) { // Raise the PropertyChanged event, passing the name of the property whose value has changed.
     this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
    } 
    }
