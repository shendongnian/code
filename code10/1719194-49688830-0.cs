	internal class MainWindowViewModel : BindableBase
	{
		public MainWindowViewModel( IRegionManager regionManager )
		{
			NavigateCommand = new DelegateCommand<string>( x => regionManager.RequestNavigate( "MainRegion", "PersonView", new NavigationParameters {{"Id", x}} ) );
		}
		public DelegateCommand<string> NavigateCommand { get; }
	}
	internal class PersonViewModel : BindableBase, INavigationAware
	{
		public PersonViewModel()
		{
			Debugger.Break();
		}
		private string _name;
		public string Name
		{
			get { return _name; }
			set { SetProperty( ref _name, value ); }
		}
		public void OnNavigatedTo( NavigationContext navigationContext )
		{
			Name = (string)navigationContext.Parameters[ "Id" ];
		}
		public bool IsNavigationTarget( NavigationContext navigationContext )
		{
			return true;
		}
		public void OnNavigatedFrom( NavigationContext navigationContext )
		{
		}
	}
	public partial class PersonView : UserControl
	{
		public PersonView()
		{
			Debugger.Break();
			InitializeComponent();
		}
	}
	<Window x:Class="PrismApplication1.Views.MainWindow"
					xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
					xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
					xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
					xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
					xmlns:mvvm="http://prismlibrary.com/"
					Title="MainWindow"
					Width="525"
					Height="350"
					mvvm:ViewModelLocator.AutoWireViewModel="True"
					mc:Ignorable="d">
		<DockPanel LastChildFill="True">
			<Button Command="{Binding NavigateCommand}"
							CommandParameter="Person A"
							Content="Person A" />
			<Button Command="{Binding NavigateCommand}"
							CommandParameter="Person B"
							Content="Person B" />
			<ContentControl mvvm:RegionManager.RegionName="MainRegion" />
		</DockPanel>
	</Window>
