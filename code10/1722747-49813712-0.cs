	public interface IView {}
    public partial class MainWindow : IView
    {
		public IMainViewModel ViewModel
		{
			get { return (IMainViewModel)DataContext; }
			set { DataContext = value; }
		}
        public MainWindow() // for design
        {
            InitializeComponent();
			ViewModel = new MainViewModel();
        }
        public MainWindow(IMainViewModel mainViewModel) // for DI
        {
            InitializeComponent();
			ViewModel = mainViewModel;
        }
    }
