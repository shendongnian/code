    public class UserPostViewModel : INotifyPropertyChanged
    {
        ImageSource _picture;
    
        public ImageSource Picture
        {
           get { return _picture; }
           set 
           {
               _picture = value;
               OnPropertyChanged(nameof(Picture));
            }
        }
    
        string _postOwner;
    
        public string PostOwner
        {
            get { return _postOwner; }
            set 
            {
                _postOwner = value;
                OnPropertyChanged(nameof(PostOwner));
            }
        }
    
        string _postOwnerLocation;
    
        public string PostOwnerLocation
        {
            get { return _postOwnerLocation; }
            set 
            {
                _postOwnerLocation = value;
                OnPropertyChanged(nameof(PostOwnerLocation));
            }
        }
    
        ....
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
