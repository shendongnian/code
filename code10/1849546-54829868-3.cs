    public partial class LoginWindow : Window
    {
        private void BtnSignup_Click(object sender, RoutedEventArgs e)
        {
            var u = new User();
            if (u.Login(con, tbxEmail.Text, tbxPassword.Text))
            {
                AppWindow a = new AppWindow();
                a.Show();
            }
            else
                lblMissingParameter.Content = "Incorrect Password or Email entered";
        }
    }
