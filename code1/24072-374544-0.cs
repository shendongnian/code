            DataTable dt = new DataTable("Table1");
            dt.Columns.Add("A");
            dt.Columns.Add("B");
            dt.Columns.Add("C");
            dt.Rows.Add(1, 2, 3);
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
