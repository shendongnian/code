    public partial class Win1 : Window
    {
        public Win1()
        {
            InitializeComponent();
        }
    
        private void CloseAndLaunchWin2()
        {
            App.ShowWin2(this);
            this.Close();
            
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CloseAndLaunchWin2();
        }
    }
