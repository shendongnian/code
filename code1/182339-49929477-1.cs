    public partial class Window2 : UserControl
    {
        public string result
        {
            get { return resultTextBox.Text; }
        }
        public Window2()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).DialogResult = true;
            Window.GetWindow(this).Close();
        }
    }
