    public partial class Form1 : Form
    {
        private Form2 _form2;
    
        public Form1()
        {
            InitializeComponent();
    
            this.textBox1.TextChanged += textBox1_TextChanged;
    
            _form2 = new Form2();
            _form2.Show();
        }
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _form2.TextBoxValue = textBox1.Text;
        }
    }
