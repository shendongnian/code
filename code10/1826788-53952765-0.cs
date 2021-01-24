	public class ImageDataViewModel : ViewModelBase
	{
		public EventHandler<bool> OnChanging;
		public ImageData Data { get; private set; }
		public ImageDataViewModel(ImageData data)
		{
			this.Data = data;
		}
		private bool _isDefault;
		public bool IsDefault
		{
			get { return _isDefault; }
			set
			{
				if (value != this._isDefault)
					OnChanging?.Invoke(this, value);
				Set(ref _isDefault, value);
			}
		}
	}
