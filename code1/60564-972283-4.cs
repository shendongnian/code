    public partial class Window1 : Window, INotifyPropertyChanged
	{
		public Window1()
		{
			InitializeComponent();
			this.DataContext = this;
		}
		public KeyedCollection<char, string> Examples
		{
			get;
			set;
		}
		private string mySelectedExample;
		public string SelectedExample
		{
			get
			{ return this.mySelectedExample; }
			set
			{
				this.mySelectedExample = value;
				this.NotifyPropertyChanged("SelectedExample");
			}
		}
		private void AnimalButtonClick(object sender, RoutedEventArgs e)
		{
			Examples = new AlphabetExampleCollection();
			Examples.Add("Ardvark");
			Examples.Add("Bat");
			Examples.Add("Cat");
			Examples.Add("Dingo");
			Examples.Add("Emu");
			NotifyPropertyChanged("Examples");
		}
		private void ObjectButtonClick(object sender, RoutedEventArgs e)
		{
			Examples = new AlphabetExampleCollection();
			Examples.Add("Apple");
			Examples.Add("Ball");
			Examples.Add("Chair");
			Examples.Add("Desk");
			Examples.Add("Eee PC");
			NotifyPropertyChanged("Examples");
		}
	
		#region INotifyPropertyChanged Members
		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
	}
	public class AlphabetExampleCollection : KeyedCollection<char, string>
	{
		public AlphabetExampleCollection() : base() { }
		protected override char GetKeyForItem(string item)
		{
			return Char.ToUpper(item[0]);
		}
	}
