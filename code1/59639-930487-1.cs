    public partial class FloatingForm : Form
    {
        MainForm _mainForm;
        public FloatingForm()
        {
            InitializeComponent();
        }
        public FloatingForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _mainForm.DoSomething(floatingFormTextBox.Text);
        }
    }
