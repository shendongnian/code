	public abstract class ViewModel : INotifyPropertyChanged
	{
		private readonly Dispatcher _dispatcher;
		protected ViewModel()
		{
			if (Application.Current != null)
			{
				_dispatcher = Application.Current.Dispatcher;
			}
			else
			{
				_dispatcher = Dispatcher.CurrentDispatcher;
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected Dispatcher Dispatcher
		{
			get { return _dispatcher; }
		}
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}
		protected void OnPropertyChanged(string propertyName)
		{
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
	}
