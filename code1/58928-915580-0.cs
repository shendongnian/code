        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = String.Format(@"Data Source={0}\Northwind.sdf",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            SqlCeConnection connection = new SqlCeConnection(connectionString);
            DataTable table = new DataTable();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter("SELECT * FROM PRODUCTS",connection);
            adapter.Fill(table);
            this.dataGrid1.DataSource = table;
        }
