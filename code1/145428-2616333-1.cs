    public class YourClassHoldingThisStuff : INotifyProperyChanged
    {
      private  ObservableCollection<ViewModel> _internal;
      private  ObservableCollection<ViewModel> _boundInternal;
      public ObservableCollection<ViewModel> BoundInternal
      {
        get { return _boundInternal; }
        set
        {
          _boundInternal = value;
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
