    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool Mode = false;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Mode = true;
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Mode = false;
            this.Close();
        }
    }
