    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            form3 = new Form3();
            test.Show();
        }
        private Form3 form3;
        private void button1_Click(object sender, EventArgs e)
        {
            form3.Close();
            Form test2 = new Form2();
            test2.Show();
            this.Hide();
        }
    }
