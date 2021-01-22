    	public class Weather : INotifyPropertyChanged
		{
			private int myHumidity;
			public int Humidity
			{
				get
				{
					return this.myHumidity;
				}
				set
				{
					this.myHumidity = value;
					NotifyPropertyChanged("Humidity");
				}
			}
			private void NotifyPropertyChanged(String info)
			{
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs(info));
				}
			}
			#region INotifyPropertyChanged Members
			public event PropertyChangedEventHandler PropertyChanged;
			#endregion
		}
