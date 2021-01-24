    public partial class ProgressBar : Window
    {
        public ProgressBar()
        {
            InitializeComponent();
        }
        private async void Window_ContentRendered(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                pbStatus.Value++;
                await Task.Delay(1000);
            }
            Close();
        }
    }
