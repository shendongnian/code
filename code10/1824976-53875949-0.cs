    public partial class UC_Main : UserControl
    {
    
        public UC_Main()
        {
            InitializeComponent();
        }
    
        private void UC1_radiobutton_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = new UC1();
        }
    
        private void UC2_radiobutton_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = new UC2();
        }
    
        private void UC3_radiobutton_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = new UC3();            
        }  
    }
