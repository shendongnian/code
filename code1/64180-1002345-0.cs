    public class CustomClass : INotifyPropertyChanged
    {
      public CustomClass()
      {
        sub1item = new ObservableDictionary<string, InnerClass>();
        // This next line may not be necessary... Changes might propogate up.
        sub1item.CollectionChanged += () => NotifyChange("Sub1Item");
      }
    
      private ObservableDictionary<string, InnerClass> sub1item;
      public ObservableDictionary<string, InnerClass> Sub1Item
      {
        get { return sub1item; }
        private set { sub1item = value; NotifyChange("Sub1Item"); }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      private void NotifyPropertyChanged(String info)
      {
        if (PropertyChanged != null)
        {
          PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
      }
    }
    
    public class InnerClass : INotifyPropertyChanged
    {
      public SomeEnum Status
      {
        get { return this.status; }
        private set { this.status = value; NotifyChange("Status"); }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      private void NotifyPropertyChanged(String info)
      {
        if (PropertyChanged != null)
        {
          PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
      }
    }
