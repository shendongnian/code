	public class MainViewModel : ViewModelBase
	{
		private MyEnum? _CurrentItem;
		public MyEnum? CurrentItem
		{
			get { return this._CurrentItem; }
			set
			{
				if (this._CurrentItem != value)
				{
					this._CurrentItem = value;
					RaisePropertyChanged(() => this.CurrentItem);
				}
			}
		}
		private ICommand _StopCommand;
		public ICommand StopCommand => this._StopCommand ?? (this._StopCommand = new RelayCommand(OnStop));
		private void OnStop()
		{
			// do something with selection here
			this.CurrentItem = null;
		}
