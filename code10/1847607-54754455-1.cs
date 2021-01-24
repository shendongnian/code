    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void aTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            aTextBlock.Margin = new Thickness(10 + aTextBox.Text.Length * 2, 0, 0, 0);
            aTextBlock.Text = aTextBox.Text;
            aTextBox.Width = 100 + aTextBox.Text.Length * 2;
            aTextBlock.Width = 100 + aTextBox.Text.Length * 2;
        }
    }
        
