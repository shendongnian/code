    public partial class BaseUserControl : UserControl
    {
        public BaseUserControl()
        {
            InitializeComponent(); //event hooked here
        }
        private void showMsgBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button clicked");
        }
    }
    public partial class TestUserControl : BaseUserControl
    {
        public TestUserControl()
        {
            InitializeComponent();
        }
    }
