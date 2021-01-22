			DataTable table = new DataTable();
			table.Columns.Add("Column1", typeof(int));
			table.Columns.Add("Column2", typeof(int));
			table.Columns.Add("Column3", typeof(int), "Column1+Column2");
			dataGridView1.DataSource = table;
