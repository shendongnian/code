    public partial class MainPage : UserControl
    {
        ServiceReference1.WebService1SoapClient myService;
    
        public MainPage()
        {
            InitializeComponent();
            myService = new ServiceReference1.WebService1SoapClient();
            myService.ExecuteScalarCompleted += myService_ExecuteScalarCompleted;
            myService.ExecuteNonQueryCompleted += myService_ExecuteNonQueryCompleted;
        }
    
        void myService_ExecuteNonQueryCompleted(object sender, 
                       ServiceReference1.ExecuteNonQueryCompletedEventArgs e)
        {
            MessageBox.Show(e.Result);
        }
    
        void myService_ExecuteScalarCompleted(object sender, 
             ServiceReference1.ExecuteScalarCompletedEventArgs e)
        {
            MessageBox.Show(e.Result);
        }
    
        private void btExecuteScalar_Click(object sender, RoutedEventArgs e)
        {
            myService.ExecuteScalarAsync(textBox1.Text);
        }
    
        private void btExecuteNonQuery_Click(object sender, RoutedEventArgs e)
        {
            myService.ExecuteNonQueryAsync(textBox1.Text);
        }
    }
