    public class Setting : INotifyPropertyChanged
    {
       private double _fontSize = 20;
       public double FontSize
       {
           get { return _fontSize; }
           set { _fontSize = value; OnPropertyChanged(); }
       }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
