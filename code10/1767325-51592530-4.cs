        public class PinsDataItem : INotifyPropertyChanged
	      {
		     public event PropertyChangedEventHandler PropertyChanged;
		     private void NotifyPropertyChanged(string name)
		       {
		         if (PropertyChanged != null)
				 PropertyChanged(this, new PropertyChangedEventArgs(name));
		       }
		     string text;
		     public PinsDataItem(string value)
		       {
		    	this.Text = value;
		       }
		public string Text
		{
			get
			{
				return text;
			}
			set
			{
				if (text != value)
				{
					text = value;
				}
				NotifyPropertyChanged("Value");
			}
		  }
	    }
