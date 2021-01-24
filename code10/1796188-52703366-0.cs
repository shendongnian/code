        public partial class vm : INotifyPropertyChanged
        {
          public event PropertyChangedEventHandler PropertyChanged;
          protected void OnPropertyChanged(string text)
          {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(text));
            }
          } 
        
          public vm()
          {
            DataTable dt;
              
            ...
          
            MyGrid = new DataView(dt);
          }
          private DataView _mygrid;
          public DataView MyGrid
          {
             get
             {
                return _mygrid;
             }
             set
             {
                _mygrid= value;
                OnPropertyChanged("MyGrid");
             }
          }
       }
