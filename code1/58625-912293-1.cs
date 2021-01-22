    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    
    namespace WPFDynamicMenuItems
    {
    	/// <summary>
    	/// Interaction logic for Window1.xaml
    	/// </summary>
    	public partial class Window1 : Window
    	{
    		private MainMenuViewModel _mainMenuVM = new MainMenuViewModel();
    
    		public Window1()
    		{
    			InitializeComponent();
    
    			this.dynamicMenuItems.Collection = this._mainMenuVM.CommandList;
    		}
    	}
    
    
    	public class MainMenuViewModel : INotifyPropertyChanged
    	{
    		private ObservableCollection<CommandViewModel> m_CommandVMList;
    
    		public MainMenuViewModel()
    		{
    			m_CommandVMList = new ObservableCollection<CommandViewModel>();
    			CommandViewModel cmv = new CommandViewModel();
    			cmv.DisplayName = "Dynamic Menu 1";
    			m_CommandVMList.Add(cmv);
    			cmv = new CommandViewModel();
    			cmv.DisplayName = "Dynamic Menu 2";
    			m_CommandVMList.Add(cmv);
    			cmv = new CommandViewModel();
    			cmv.DisplayName = "Dynamic Menu 3";
    			m_CommandVMList.Add(cmv);
    
    			CommandViewModel nestedCMV = new CommandViewModel();
    			nestedCMV.DisplayName = "Nested Menu 1";
    			cmv.CommandList.Add(nestedCMV);
    
    			nestedCMV = new CommandViewModel();
    			nestedCMV.DisplayName = "Nested Menu 2";
    			cmv.CommandList.Add(nestedCMV);
    		}
    		public ObservableCollection<CommandViewModel> CommandList
    		{
    			get { return m_CommandVMList; }
    			set { m_CommandVMList = value; OnPropertyChanged("CommandList"); }
    		}
    
    		protected void OnPropertyChanged(string propertyName)
    		{
    			//	Hook up event...
    		}
    
    		#region INotifyPropertyChanged Members
    
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		#endregion
    	}
    
    	public class CommandViewModel : INotifyPropertyChanged
    	{
    		private ObservableCollection<CommandViewModel> m_CommandVMList;
    
    		public CommandViewModel()
    		{
    			this.m_CommandVMList = new ObservableCollection<CommandViewModel>();
    		}
    
    		public string DisplayName { get; set; }
    
    		public ObservableCollection<CommandViewModel> CommandList
    		{
    			get { return m_CommandVMList; }
    			set { m_CommandVMList = value; OnPropertyChanged("CommandList"); }
    		}
    
    		protected void OnPropertyChanged(string propertyName)
    		{
    			//	Hook up event...
    		}
    
    		#region INotifyPropertyChanged Members
    
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		#endregion
    	}
    }
