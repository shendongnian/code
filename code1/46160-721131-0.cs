    public partial class Form1 : Form
    {
        private Form2 _Form2;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_Form2 != null)
                _Form2.Dispose();
            _Form2 = new Form2();
            _Form2.Disposed += delegate
            {
                _Form2.Dispose();
                _Form2 = null;
            };
            _Form2.Show();
        }
    }
