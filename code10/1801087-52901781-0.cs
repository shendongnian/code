    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!Application.Current.Properties.ContainsKey("main_page_visited"))
            {
                Application.Current.Properties["main_page_visited"] = true;
                label.Text = "First Time visited";
            }
            else
            {
                label.Text = "Second+ Time visited";
            }
        }
    }
