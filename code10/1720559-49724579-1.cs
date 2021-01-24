    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private MouseActivateListener textBox1Listener;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBox1Listener = new MouseActivateListener(textBox1);
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1Listener.MouseActivated)
            {
                MessageBox.Show("Mouse Enter");
            }
            else
            {
                MessageBox.Show("Tab Enter");
            }
        }
    }
