    public partial class LoginForm : Form
    {
        public string Username { get; set; }
        public LoginForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //the login process has been successful
            this.Username = "some user";
            this.DialogResult = DialogResult.OK;
        }
    }
