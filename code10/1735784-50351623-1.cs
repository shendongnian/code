        namespace WindowsFormsApp1
        {
    public partial class usercontrol_2 : UserControl
    {
        public event MyEventDelegate userControlButtonClicked;
        public usercontrol_2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyEventDelegate med = userControlButtonClicked;
            if (med != null)
            {
                med(this, "2");
            }
        }
    }
        }
