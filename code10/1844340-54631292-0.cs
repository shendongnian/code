		<Button Name="scatterButton" Content="click" Click="ScatterButton_Click" />
		<Charting:Chart x:Name="test_chart">
			<Charting:ScatterSeries ItemsSource="{x:Bind LstSource}" IndependentValuePath="Name" DependentValuePath="Amount"  />
		</Charting:Chart>
SmartPhone class example:
public class SmartPhone : INotifyPropertyChanged
	{
		private int _amount;
		public string Name { get; set; }
		public int Amount
		{
			get { return _amount; }
			set
			{
				this._amount = value;
				NotifyPropertyChanged();
			}
		}
		public int Other { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
MainPage class:
	public sealed partial class MainPage : Page
	{
		public ObservableCollection<SmartPhone> LstSource
		{
			get { return lstSource; }
		}
		private ObservableCollection<SmartPhone> lstSource = new ObservableCollection<SmartPhone>
		{
			new SmartPhone() {Name = "IPhone", Amount = 10, Other = 1},
			new SmartPhone() {Name = "Android", Amount = 30, Other = 1},
			new SmartPhone() {Name = "UWP", Amount = 25, Other = 2}
		};
		public MainPage()
		{
			this.InitializeComponent();
			//LoadChartContent();
		}
		private void ScatterButton_Click(object sender, RoutedEventArgs e)
		{
			lstSource[0].Amount = 30;
			//lstSource.Add(new SmartPhone{Amount = 10, Name = "asd", Other = 2});
			
		}
	}
I hope it's all you need.
