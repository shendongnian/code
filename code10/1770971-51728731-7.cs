    public partial class Form2 : Form
    {
        public string TextBoxValue
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
        public Form2()
        {
            InitializeComponent();
        }
    }
