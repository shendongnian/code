    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();
        }
    
        // global variable of Dogs Class instance - pass it a Form1 instance
        public Dogs _Dogs;
    
        private void Form1_Load(object sender, EventArgs e)
        {
            // initilize Dogs() class and pass this instance
            _Dogs = new Dogs(this);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            // show textbox1 text from Dogs class
            _Dogs.showTextBox1Text();
            // you can also just pass the value of textbox1 to Dogs instance
            _Dogs.passedTextFromForm1(textBox1.Text);
        }
    }
