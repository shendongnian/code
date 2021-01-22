    public DataTable GridView
        {
            get { return dataGridView1.DataSource as DataTable; }
            set { dataGridView1.DataSource = value;
                splitContainer1.SplitterDistance = dataGridView1.Width;
            }
        }
