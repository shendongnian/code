    private Form2 frm2;
      
    public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var text = Textbox1.Text;
            frm2.TextChanged.Invoke(text , new EventArgs());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            frm2 = new Form2();
           frm2.Show();
        }
