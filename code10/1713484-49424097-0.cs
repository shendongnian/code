    public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(txtFirst_KeyDown);
            this.PreviewKeyDown += new KeyEventHandler(txtSecond_KeyDown);
            
        }
        
        private void txtFirst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Down)
            {               
                txtSecond.Focus();
            }
            
        }
       
        private void txtSecond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Up)
            {
                txtFirst.Focus();
            }
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            txtFirst.Focus();
        }
