    public partial class Window1 : Window, INotifyPropertyChanged
	{
		public Window1()
		{
			InitializeComponent();
			this.DataContext = this;
		}
		private bool myBoolean;
		public bool MyBoolean
		{
			get
			{
				return this.myBoolean;
			}
			set
			{
				this.myBoolean = value;
				this.NotifyPropertyChanged("MyBoolean");
			}
		}
		#region INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
			    PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}
		#endregion
	}
