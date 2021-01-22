    class ObservableObject : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
      
      protected void OnPropertyChanged(string name)
      {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }
    }
