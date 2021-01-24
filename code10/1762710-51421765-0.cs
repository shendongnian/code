    public partial class MainForm : Form
    {
        private Child1Form child1 = null;
        public MainForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (child1 == null)
            {
                child1 = new Child1Form();
                child1.MdiParent = this;
                child1.Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (child1 != null)
            {
                child1.Close();
                child1.Dispose();
                child1 = null;
            }
        }
    }
