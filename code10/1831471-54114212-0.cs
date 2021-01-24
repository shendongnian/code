    public partial class Form1 : Form
    {
        int clickCount;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            clickCount = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            clickCount++;
            switch (clickCount)
            {
                case 1:
                    textBox1.Text = "1";
                    break;
                case 2:
                    textBox2.Text = "1";
                    break;
                case 3:
                    textBox3.Text = "1";
                    break;
                case 4:
                    textBox4.Text = "1";
                    break;
                case 5:
                    textBox5.Text = "1";
                    break;
                default:
                    MessageBox.Show("clickCount outside of range (5)");
                    break;
            }           
        }
    }
