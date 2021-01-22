    public partial class MainForm : Form
    {
        FloatingForm _floatingForm;
        public MainForm()
        {
            InitializeComponent();
        }
        public void DoSomething(string text)
        {
            mainFormTextBox.Text = text;
            this.Refresh();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            _floatingForm = new FloatingForm(this);
            _floatingForm.Show();
        }
    }
