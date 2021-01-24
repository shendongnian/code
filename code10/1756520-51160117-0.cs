    public partial class Form2 : Form
    {
        private readonly Form1 _form1;
        public Form2 (Form1 from1)
        {
            _form1 = form1;
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            _form1.label2.ForeColor = Color.Red;
        }
    }
