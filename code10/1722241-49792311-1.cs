        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            LoadData(ref dt);
            dataGridView1.DataSource = dt;
        }
