    public sealed partial class MainPage : Page
    {
        string UserID = LoginPage.UserID;
        public MainPage()
        {
            this.InitializeComponent();
            UserIDTextBlock.Text = UserID;
        }
    }
