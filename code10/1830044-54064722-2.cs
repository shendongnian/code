    public class MyData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")  
        {  
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
      private double _count;
      public double Count 
      { 
        get
        { return _count; }
        set
        { 
          _count = value;
          NotifyPropertyChanged();
        }
    }
    List<MyData> data { get; set; }
