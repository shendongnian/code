	public class SolidObjectViewModel : INotifyPropertyChanged
	{
		private SolidObject _solidObject;
		public SolidObjectViewModel(SolidObject solidObject)
		{
			_solidObject = solidObject;
			_solidObject.PropertyChanged += (sender, e) =>
			{
				bool positionChanged = e.PropertyName == "Position";
				bool sizeChanged = e.PropertyName == "Size";
				if (positionChanged)
					FirePropertyChanged("Position");
				if (sizeChanged)
					FirePropertyChanged("Size");
				if (positionChanged || sizeChanged)
					FirePropertyChanged("Bounds");
			};
		}
		public Point Position
		{
			get { return _solidObject.Position; }
			set { _solidObject.Position = value; }
		}
		public Size Size
		{
			get { return _solidObject.Size; }
			set { _solidObject.Size = value; }
		}
		public Rect Bounds
		{
			get
			{
				return new Rect(Position.X - Size.Width / 2, Position.Y - Size.Height / 2, Size.Width, Size.Height);
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		private void FirePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
