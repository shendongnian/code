    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        } 
    
        void Icon1_Tapped (object sender, System.EventArgs e)
        {
            var page = new HomePage();
            PlaceHolder.ContentView = page.Content;
    
        }
    }
