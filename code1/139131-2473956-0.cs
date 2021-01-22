    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            Action<string> showMessage = ShowMessage;
            form.ClosingMethod(showMessage);
            form.Show();
        }
        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
    public partial class Form2 : Form
    {
        private Action<string> _showMessage;
        public Form2()
        {
            InitializeComponent();
        }
        public void ClosingMethod(Action<string> showMessage)
        {
            _showMessage = showMessage;
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_showMessage != null)
            {
                _showMessage("hippo");
            }
        }
    }
