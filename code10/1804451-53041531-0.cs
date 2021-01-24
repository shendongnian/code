    public sealed partial class LoginPage : Page
    {
        public static string UserID;
        public LoginPage()
        {
            this.InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
             if(/* Login Success/Your Condition to check user id validity */)
             {                 
                 UserID = UserIDTextBox.Text;
                 Frame.Navigate(typeof(MainPage));
             }
        }
    }
