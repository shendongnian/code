    RevisionMapViewModel : INotifyPropertyChanged
    //...your code here
    public event PropertyChangedEventHandler PropertyChanged;
    protected void NotifyPropertyChanged(String info) {
        if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
