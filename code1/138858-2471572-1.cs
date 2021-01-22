    public class MainForm : Form
    {
        private bool isDataModified;
        public MainForm()
        {
            InitializeComponent();
            textBox1.TextChanged += DataModified;
            textBox2.TextChanged += DataModified;
            // etc.
            userControl1.Modified += DataModified;
            userControl2.Modified += DataModified;
            // etc.
        }
        private void DataModified(object sender, EventArgs e)
        {
            isDataModified = true;
        }
    }
