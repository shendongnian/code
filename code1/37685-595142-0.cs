    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public void y()
        {
            MessageBox.Show(checkBox1.Checked.ToString());
        }
        static void x(Form f)
        {
            f.y();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            x(this);
        }
    }
