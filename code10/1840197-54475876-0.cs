    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 test = new Form1();
            test.FormClosed += Test_FormClosed;
      
            test.Show();
        }
        private void Test_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("closed -- do something else here!");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
