    public partial class Form1 : Form
    {
        private Form2 _form2;
    
        public string TextBoxValue
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
    
        public Form1()
        {
            InitializeComponent();
    
            this.textBox1.TextChanged += (sender, e) => { _form2.TextBoxValue = textBox1.Text; };
    
            _form2 = new Form2();
            _form2.Show();
        }
    }
