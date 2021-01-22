    List<int> collection = new List<int>();
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSourceChanged += listbox1_Changed;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            collection.Add(new Random().Next(100));
            listBox1.BeginUpdate();
            listBox1.DataSource = null;
            listBox1.DataSource = collection;
            listBox1.EndUpdate();
        }
        private void listbox1_Changed(object sender, EventArgs e)
        {
            textBox1.Text = collection.Count.ToString();
        }
