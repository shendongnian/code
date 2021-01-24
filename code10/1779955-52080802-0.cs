            public FormResultadosFotos(DataGridView dataGridView)
            {
                InitializeComponent();
                dataGridView1.Rows.Clear();
    
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    dataGridView1.Rows.Add(row.Cells[0].Value, row.Cells[1].Value);
                }
            }
