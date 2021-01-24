    public class DetailViewModel : BaseViewModel
    {
        int _trackID;
        public int trackID;
        { 
            get { return _trackID; }
            set 
            { 
                _trackID = value;
                notifyPropertyChanged(nameof(trackID));
            } 
        }
        ~~~~
     }
