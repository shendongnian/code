	public class MainViewModel : ViewModelBase
	{
		private object _MyChild;
		public object MyChild
		{
			get { return this._MyChild; }
			set
			{
				if (this._MyChild != value)
				{
					this._MyChild = value;
					RaisePropertyChanged(() => this.MyChild);
				}
			}
		}
	}
