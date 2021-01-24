    public partial class FormA : Form
    {
        public FormA()
        {
            InitializeComponent();
        }
        MainForm fm;
        public FormA(MainForm fm)
        {
            InitializeComponent();
            this.fm = fm;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fm.textBox1.Text = comboBox1.Text;
        }
    }
