    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName)
    {
       if (this.PropertyChanged != null)
         this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
