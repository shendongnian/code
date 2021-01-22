    public class MyClass : HeaderedContentControl, INotifyPropertyChanged
    {
      protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
      {
        var handler = PropertyChanged;
        if(handler!=null) handler(this, new PropertyChangedEventArgs(e.Property.Name));
        base.OnPropertyChanged(e);
      }
      public event PropertyChangedEventHandler PropertyChanged;
    }
