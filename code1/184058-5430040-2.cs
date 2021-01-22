    public partial class LoginForm : Form
    {
        bool isAuthorized;
        bool exit;
        public bool IsAuthorized    { get { return this.isAuthorized;   } }
        public bool IsExit          { get { return this.exit;           } }
        public LoginForm()
        {
            isAuthorized    = false;
            exit            = false;
            InitializeComponent();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            exit = true; 
			this.Close();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
			if (Login.Text != "")
			{
				if (Login.Text.ToUpper() == "ADMIN")
				{
					if (Password.Text == Crypto.DecryptStringAES(Model.DecryptRegisteryValue("Password"), "Password"))
						isAuthorized = true;
				}
				else
				{
					if (QueryBuilder.Login(Login.Text, Password.Text))
						isAuthorized = true;
				}
			}
			this.Close();
        }
    }
