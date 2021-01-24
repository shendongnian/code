    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void ButtonLogoutClick(object sender, EventArgs e)
        {
            LoginUser();
        }
        private void MainFormShown(object sender, EventArgs e)
        {
            LoginUser();
        }
        private void LoginUser()
        {
            using (var loginForm = new LoginForm())
            {
                var loginResult = loginForm.ShowDialog();
                if (loginResult == DialogResult.OK)
                {
                    //Login Success
                    var userId = loginForm.User.ID; //Query user ID from Login Form for example
                }
                else
                {
                    //Login Failed
                    Close(); //Close Program for example
                }
            }
        }
    }
