    public partial class Pop_a : Window
    {
        public Pop_a()
        {
            InitializeComponent();
        }
    
        private void Bu_a_Click(object sender, RoutedEventArgs e)
        {
            var pop_b = new Pop_b();
    
            pop_b.Show();
    
            this.Activate();
        }
    }
