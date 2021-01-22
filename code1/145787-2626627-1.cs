    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Ctrl-F was Pressed.");
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                button1.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
