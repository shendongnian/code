    class Model : INotifyPropertyChanged
    	{
    		public bool enabled;
    		public bool IsLoggedIn
    		{
    			get
    			{
    				return enabled;
    			}
    			set
    			{
    				enabled = value;
    				OnPropertyChanged("IsLoggedIn");
    			}
    		}
    		public event PropertyChangedEventHandler PropertyChanged;
    		public void OnPropertyChanged([CallerMemberName]string property = "")
    		{
    			if (PropertyChanged != null)
    				PropertyChanged(this, new PropertyChangedEventArgs(property));
    		}
    	}
