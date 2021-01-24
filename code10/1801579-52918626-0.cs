    public class FeedItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private int _likes;
        public int Likes
        {
            get => _likes;
            set
            {
                _likes = value;
                if (PropertyChanged != null)
                {
                        PropertyChanged(this, new 
                            PropertyChangedEventArgs(nameof(Likes)));
                }
            }
        }
    }
