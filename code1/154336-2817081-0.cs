    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();
        public Form1()
        {
            InitializeComponent();
            ds.Tables.Add("dt");
            ds.Tables[0].Columns.Add("id");
            ds.Tables[0].Columns.Add("email");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int count = ds.Tables[0].Rows.Count;
            ds.Tables[0].Rows.Add(count, textBox1.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ds.Tables[0].WriteXml("email.xml");
        }
    }
