    public partial class ThirdWindow: Window
    {
        public ThirdWindow(string name)
        {
            InitializeComponent();      
        }
    
        public void LstThanks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LstThanks.Items.Add(name);
        }
    }
