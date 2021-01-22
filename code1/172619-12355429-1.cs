    public partial class LoginForm : Form
    {
        private string username = "";
        public LoginForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Do login processing and assuming success call the following;
            UserLogOn.UserName = textBox1.Text;
            username = textBox1.Text;
            ((Form1)this.Owner).Username = this.username;
            this.DialogResult = DialogResult.OK;
        }
    }
  
