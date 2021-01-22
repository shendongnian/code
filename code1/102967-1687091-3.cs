	public partial class Window1 : Window, INotifyPropertyChanged
	{
		public Window1()
		{
			this.TmpStr = "Windows Created";
			this.InitializeComponent();
			this.DataContext = this;
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public string TmpStr { get; set; }
		public int TmpVal { get; set; }
		private void viewButton_Click(object sender, RoutedEventArgs args)
		{
			this.TmpStr = "Button clicked";
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs("TmpStr"));
			}
		}
	}
