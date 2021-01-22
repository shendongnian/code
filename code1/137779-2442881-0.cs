    	private void getData(string selectCommand)
		{
			string connectionString = @"Server=localhost;User=SYSDBA;Password=masterkey;Database=C:\data\test.fdb";
			dataAdapter = new FbDataAdapter(selectCommand, connectionString);
			data = new DataTable();
			dataAdapter.Fill(data);
			bindingSource.DataSource = data;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			dataAdapter.Fill(data);
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			dataGridView1.DataSource = bindingSource;
			getData("SELECT * FROM cities");
		}
