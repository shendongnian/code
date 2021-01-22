    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Process.GetCurrentProcess().Id.ToString();
        }
    }
