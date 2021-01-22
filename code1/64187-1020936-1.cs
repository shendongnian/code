    // Should implement INotifyPropertyChanged if the dictionary itself
    // can be changed and not only its items
    public class CustomClass {
        ObservableDictionary sub1item;
        // Bunch of properties and methods in this class
        // INotify not implemented
    }
    
    
    public class InnerClass : INotifyProperyChanged {
        // Bunch of properties and methods in this class
        // INotify not implemented
        public SomeEnum Status{
            get{ return this.status; }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
    
    
    protected void NotifyPropertyChanged(string propertyName)
    {
        if(PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    
    // where ever this.status is changed directly,
    // call NotifyPropertyChanged("Status")
    // (at end of that method)
    //
    // if this.status is changed from outside class (if public),
    // then add a public method NotifyStatusChanged() which calls
    // NotifyPropertyChanged("Status")
    //
    // If Status property has a set{} then if new value != this.status,
    // call NotifyPropertyChanged("Status") at end of setter
    
    }
