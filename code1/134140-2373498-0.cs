	public class TimedSample : INotifyPropertyChanged
	{
		private string _Value;
		public string Value
		{
			get { return _Value; }
			set
			{
				_Value = value;
				NotifyPropertyChanged("Value");
			}
		}
		private DateTime _Begin;
		public DateTime Begin
		{
			get { return _Begin; }
			set
			{
				_Begin = value;
				NotifyPropertyChanged("Begin");
			}
		}
		private DateTime _End;
		public DateTime End
		{
			get { return _End; }
			set
			{
				_End = value;
				NotifyPropertyChanged("End");
			}
		}
		private bool _NowInRange;
		public bool NowInRange
		{
			get { return _NowInRange; }
			private set
			{
				_NowInRange = value;
				NotifyPropertyChanged("NowInRange");
			}
		}
		private void NotifyPropertyChanged(string name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
