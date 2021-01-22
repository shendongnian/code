    public partial class Form1 : Form
    {
        public delegate void FormReturn(string s);
        private string var1;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Form2(ReturnFunc);
            frm.ShowDialog();
        }
    
        protected void ReturnFunc(string text)
        {
            var1 = text;
        }
    }
    public partial class Form2 : Form
    {
        private Form1.FormReturn returnFunc;
    
        public Form2(Form1.FormReturn del)
        {
            InitializeComponent();
            returnFunc = del;
        }
    
        private void btnClose_Click(object sender, EventArgs e)
        {
            returnFunc.Invoke(txtText.Text);
            Close();
        }
    }
