    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show();
        }
        public string LabelText
        {
            get { return Lbl.Text; }
            set { Lbl.Text = value; }
        }
    }
