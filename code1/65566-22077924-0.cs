        public Form1()
		{
			InitializeComponent();
            dataGridView1.DataSource = source;
            for (int i = 0; i < dataGridView1.Columns.Count - 1; i++) {
				dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
			dataGridView1.Columns[dataGridView1.Columns.Count].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}
        
        void Form1Shown(object sender, EventArgs e)
        {
        	for ( int i = 0; i < dataGridView1.Columns.Count; i++ )
			{
				int colw = dataGridView1.Columns[i].Width;
				dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
				dataGridView1.Columns[i].Width = colw;
			}
        }
