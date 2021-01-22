    public class YourClassHoldingThisStuff : INotifyProperyChanged
    {
      private  ObservableCollection<ViewModel> _internal;
      public ObservableCollection<ViewModel> BoundInternal
      {
        get { return _internal; }
        set
        {
          _internal = value;
          NotifyPropertyChanged("BoundInternal");
        };
      }
      public event PropertyChangedEventHandler PropertyChanged;
      private void NotifyPropertyChanged(string name)
      {
        if (PropertyChanged != null)
          PropertyChanged(this, new ProperytChangedEventArgs(name));
      }
    }
