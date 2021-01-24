    public partial class MyBaseForm : Form
    {
        public MyBaseForm()
        {
            InitializeComponent();
        }
        private void MyBaseForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This will show both in run-time and design time.");
            if (!DesignMode)
                MessageBox.Show("This will show just in run-time");
        }
    }
