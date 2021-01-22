    public partial class SomeForm : Form
    {
        public SomeForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        public string SomeValue { get { return textBox1.Text; } }
    }
    ...
    private string GetSomeInput()
    {
        SomeForm f = new SomeForm();
        if (f.ShowDialog() == DialogResult.OK)
            return f.SomeValue;
        return null;
    }
