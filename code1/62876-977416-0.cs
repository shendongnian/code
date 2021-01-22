    public class MyClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string title;
        public string Title {
          get { return title; } 
          set { 
            if(value != title)
            {
              this.title = value;
              if (this.PropertyChanged != null)
              {
                 this.PropertyChanged(this, new PropertyChangedEventArgs("Title"));
              }
           }
      }
