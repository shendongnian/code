    namespace TestApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public bool DoValidate(string username, string password)
            {
                MessageBox.Show(string.Format("I got called with {0} : {1}",username,password));
                return true;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 F = new Form2(DoValidate);
                F.ShowDialog();
            }
        }
    }
    namespace TestApp
    {
        public partial class Form2 : Form
        {
            private Form2()
            {
                InitializeComponent();
            }
            public delegate bool LoginFn(string Uname, string pword);
            private LoginFn m_CallFn;
            public Form2(LoginFn del)
            {
                InitializeComponent();
                m_CallFn = del;
            }
    
            private void cmdLogon_Click(object sender, EventArgs e)
            {
                if (!m_CallFn(txtUser.Text, txtPassword.Text))
                {
                    MessageBox.Show("Fail");
                }
                else
                {
                    MessageBox.Show("Good");
                }
    
            }
        }
    }
