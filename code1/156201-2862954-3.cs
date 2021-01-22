    public partial class PrintPreviewWindow : ChildWindow
    {
        public PrintPreviewWindow(Customer customer)
        {
            InitializeComponent();
            this.DataContext = customer;
        }
    
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
