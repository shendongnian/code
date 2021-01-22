    public class TestClass : INotifyPropertyChanged
    {
        private DateTime date;
	    
        public DateTime Date 
	    { 
        	get { return date; }
        	set { date = value; NotifyPropertyChanged("Date"); } 
    	}
	
        private void NotifyPropertyChanged(string info)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }	
    }
