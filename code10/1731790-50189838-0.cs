    public partial class Login : Form
    {
        szofttech2Entities context = new szofttech2Entities();
        public Login()
        {
            InitializeComponent();
        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            var password = string.Empty;
            try
            {
                password = (from u in context.Users
                            where u.UserName == textBoxUserName.Text
                            select u.Password).Single();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show($"None or more than one user found matching {textBoxUserName.Text}");
            }
            if (!string.IsNullOrEmpty(password))
            {
                if (textBoxPassword.Text == password)
                {
                    Order order = new Order();
                    order.Show();
                    this.Hide();
                }
                else
                {
                    labelWrongUserPassword.Visible = true;
                }
            }
        }
    }
