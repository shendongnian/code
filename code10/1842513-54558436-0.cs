    public class Model : INotifyPropertyChanged
    {
        //This is all that the interface requires
        public event PropertyChangedEventHandler PropertyChanged;
    
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _text = value;
                if(PropertyChanged != null)
                    PropertyChange(this, new PropertyChangedEventArgs("Title")); 
            }
        }
    }
