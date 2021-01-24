        namespace WindowsFormsApp1
        {
            public delegate void MyEventDelegate(object sender, string name);
    public partial class Form1 : Form
    {
        usercontrol_1 _ctrl1 = null;
        usercontrol_2 _ctrl2 = null;
        public Form1()
        {
            InitializeComponent();
            _ctrl1 = new usercontrol_1();
            _ctrl1.Dock = DockStyle.Fill;
            _ctrl1.userControlButtonClicked += userControlButtonClicked;
            _ctrl2 = new usercontrol_2();
            _ctrl2.Dock = DockStyle.Fill;
            _ctrl2.userControlButtonClicked += userControlButtonClicked;
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            userControlButtonClicked(_ctrl1, "1");
        }
        private void userControlButtonClicked(object sender, string name)
        {
            panel1.Controls.Clear();
            if (sender.Equals(_ctrl1))
            {
                panel1.Controls.Add(_ctrl2);
            }
            else if (sender.Equals(_ctrl2))
            {
                panel1.Controls.Add(_ctrl1);
            }
        }
    }
}
        namespace WindowsFormsApp1
        {
    public partial class usercontrol_1 : UserControl
    {
        public event MyEventDelegate userControlButtonClicked;
        public usercontrol_1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyEventDelegate med = userControlButtonClicked;
            if (med != null)
            {
                med(this, "1");
            }
        }
    }
