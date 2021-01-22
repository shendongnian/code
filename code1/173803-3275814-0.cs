        public partial class Form1 : Form
    {
        FileProcess fileprocess;
        public Form1()
        {
            InitializeComponent();
            fileprocess = new FileProcess();
        }
        public void writeFile()
        {        
            fileprocess.writeFile(textBox1.Text,textBox2.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            writeFile();
        }
    }
