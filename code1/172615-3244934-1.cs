    public partial class Form1 : Form
    {
        private string _username;
        public Form1()
        {
            InitializeComponent();
            this.OpenLoginForm();
        }
    
        public string Username 
        { 
            get
            { 
                return this._username;
            } 
            set
            { this._username=value; 
                this.Text=string.Format("Title string [{0}]", this._username);
            }
        }
    
        private void OpenLoginForm()
        {
            LoginForm frm = new LoginForm();
            frm.ShowDialog(this);
    
        }
    }
    public partial class LoginForm : Form
    {
        private string username = "testnname";
        public LoginForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Do login processing and assuming success call the following;
            ((Form1)this.Owner).Username = this.username;
            this.DialogResult = DialogResult.OK;
        }
    }
