    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string TextBoxValue
        {
            get { return textBox1.Text;} 
            set { textBox1.Text = value;}
        }                       
    }
 
