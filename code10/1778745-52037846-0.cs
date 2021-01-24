    public class ControlItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler propertyChanged;
        private BitmapSource picture;
    
        public int Score { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Index { get; set; }
    
        public BitmapSource Picture
        {
           get { return picture; }
           set 
               {
                   picture = value;
                   NotifyPropertyChanged();
                }
        }
    
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
           if (PropertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
