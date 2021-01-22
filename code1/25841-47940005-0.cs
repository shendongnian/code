        Form2 f2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            f2.UpdateData(DateTime.Now.ToString());
            if (!f2.Visible) f2.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            f2.ShowDialog();
            MessageBox.Show("Done");
        }
    }
