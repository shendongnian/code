            DataGridView dataGridView1;
    
            public Form1()
            {
                InitializeComponent();
                dataGridView1 = new System.Windows.Forms.DataGridView();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Dock = DockStyle.Fill;
                // we will create two columns that will resize based on content within cells
                for (var i = 0; i < 2; i++)
                {
                    var column = new DataGridViewTextBoxColumn()
                    {
                        HeaderText = $"Column{i} - AllCells",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    };
                    dataGridView1.Columns.Add(column);
                }
                // And one column that fill fill the rest of the grid 
                var fillColumn = new DataGridViewTextBoxColumn()
                {
                    HeaderText = "FillColumn",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                dataGridView1.Columns.Add(fillColumn);
                // so we've got grid with 3 columns let's fill some random data
                dataGridView1.Rows.Add("test", "test", "test test test");
                dataGridView1.Rows.Add("test", "test", "test test test");
                dataGridView1.Rows.Add("test", "test", "test test test");
                dataGridView1.Rows.Add("test", "test", "test test test");
                Controls.Add(dataGridView1);
            }
