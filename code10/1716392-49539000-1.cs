    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.SelectedId = 100;
            f2.Show();
        }
    }
