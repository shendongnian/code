	class ApplyKMM
	{
		#region Properties
		static BitmapImage _Filepath;
		public static BitmapImage Filepath
		{
			get { return _Filepath; }
			set { if (_Filepath != value) { _Filepath = value; NotifyPropertyChanged(nameof(Filepath)); } }
		}
		#endregion
		
		#region Static NotifyPropertyChanged
		public static void NotifyStaticPropertyChanged(string propertyName)
		{
			StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
		}
		
		public void NotifyAllStaticPropertyChanged()
		{
			NotifyStaticPropertyChanged(string.Empty);
		}
		
		public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
		#endregion
	}
