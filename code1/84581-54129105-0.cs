    	public abstract class PropertyNotifier: INotifyPropertyChanged
	{
		#region INotifyPropertyChanged support code
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
		{
			bool result = false;
			if (!Object.Equals(storage, value))
			{
				storage = value;
				OnPropertyChanged(propertyName);
				result = true;
			}
			return result;
		}
		#endregion INotifyPropertyChanged support code
	}
