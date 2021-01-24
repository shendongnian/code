    public class YourVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    	
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    	
        private ParamViewModel[] cardChoice;
    	
        public ParamViewModel[] CardChoice
        {
            get { return cardChoice; }
            set 
    		{ 
    			cardChoice = value;
    			OnPropertyChanged("CardChoice")
    		}
        }
    }
