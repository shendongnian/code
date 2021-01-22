    public class Candy : INotifyPropertyChanged
    {
      string _CandyName;
      public string CandyName
      {
        get { return _CandyName;}
        set { _CandyName = value; OnPropertyChanged("CandyName");
      }
      
      public event PropertyChangedEventHandler OnPropertyChanged;
    
      void OnPropertyChanged(string prop)
      {
        if (PropertyChanged != null) PropertyChanged(this,new PropertyChangedEventArgs(prop));
      }
    }
