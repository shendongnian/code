    namespace test1
    {
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.checkB;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                Form1 f1 = (Form1)this.Owner;
                f1.button1.Visible = false; 
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.checkB = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
    }
    }
