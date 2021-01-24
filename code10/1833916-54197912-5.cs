    public partial class Form1 : Form
    {
        public bool dtgmb = false;
        public Form1()
        {
            InitializeComponent();
            FormCollection.Form1 = this;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Forms saved in class called FormsCollection
            FormCollection.Form1.Hide();
            FormCollection.Form2.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormCollection.Form1.Hide();
            dtgmb = true;
            FormCollection.Form2.Show();
        }
        private void Form1_Click(object sender, EventArgs e)
        {
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormCollection.Form1 = null;
        }
    }
    public static class FormCollection
    {
        public static Form1 Form1;
        public static Form2 Form2;
    }
