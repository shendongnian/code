    class PersonViewModel : INotifyPropertyChanged
    {
     private Person Model;
     public ViewModel(Person model)
     {
      this.Model = model;
     }
    
     public string Name
     {
      get { return Model.Name; }
      set
      {
       Model.Name = value;
       OnPropertyChanged("Name");
      }
     }
    
     public event PropertyChangedEventHandler PropertyChanged;
     private void OnPropertyChanged(string propertyName)
     {
      var e = new PropertyChangedEventArgs(propertyName);
      PropertyChangedEventHandler changed = PropertyChanged;
      if (changed != null) changed(this, e);
     }
    }
