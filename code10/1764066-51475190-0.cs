    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                listView1.Items.Add("ABC");
                listView1.Items.Add("PQR");
                listView1.Items.Add("XYZ");
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 frm2 = new Form2(listView1);
                frm2.Show();
    
            }
        }
