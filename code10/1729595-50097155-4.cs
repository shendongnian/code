    public partial class MainWindow : INavigator
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigate( new Page1(this) );
        }
        public void Navigate( Page p )
        {
            MainFrame.Navigate( p );
        }
    }
