    public partial class Form2 : Form
    {
        public event EventHandler Button1Click;
        public string Message { get { return txtMessage.Text; } }
        public Form2()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            EventHandler handler = Button1Click;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
