    public partial class LoginScreen : System.Windows.Forms.Form
    {
        ApplicationWindow window;
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void OnFormClosed( object sender, FormClosedEventArgs e )
        {
            this.Show();
        }
        private void OnOK( object sender, EventArgs e )
        {
            this.Hide();
            window = new ApplicationWindow();
            window.FormClosed += OnFormClosed;
            window.Show();
        }
    }
