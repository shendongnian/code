    private void button1_Click(object sender, EventArgs e)
    {
            Form2 frm2 = new Form2(textBox1.Text);
            frm2.Show();    
    }
--------------------------------------------------------------------
     public Form2(string qs)
        {
            InitializeComponent();
            textBox1.Text = qs;
            
        }
