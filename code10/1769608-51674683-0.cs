    public class YourCustomObject : INotifyPropertyChanged
    {
        public string YourProperty { get; set; }  // Remember to rise propertychanged
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class YourViewModel 
    {
        public ObservableCollection<YourCustomObject> Objects { get; set; }
    }
