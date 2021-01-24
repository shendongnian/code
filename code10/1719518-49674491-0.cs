    YourViewModel : BaseClass, INotifyPropertyChanged 
(...)
    public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
    public void OnPropertyChanged([CallerMemberName]string propertyName="")
    {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
