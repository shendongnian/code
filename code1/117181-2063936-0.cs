    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void NonModalButtonClick(object sender, RoutedEventArgs e)
        {
            new Window1 { Owner = this }.Show();
        }
        private void ModalButtonClick(object sender, RoutedEventArgs e)
        {
            new Window1 { Owner = this }.ShowDialog();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Activate();
            }
        }
    }
