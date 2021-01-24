            private void Insert_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            string table = "brands";
            string sql = "SELECT * FROM " + table;
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(sql, conn);
            conn.Open();
            MySqlCommandBuilder myCommandBuilder = new MySqlCommandBuilder(myDataAdapter);
            DataSet myDataSet = new DataSet();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            dt = ((DataView)dtGrid.ItemsSource).ToTable() as DataTable;
            ds.Tables.Add(dt);
            myDataAdapter.InsertCommand = myCommandBuilder.GetInsertCommand();
            myDataAdapter.UpdateCommand = myCommandBuilder.GetUpdateCommand();
            myDataAdapter.DeleteCommand = myCommandBuilder.GetDeleteCommand();
            myDataAdapter.Fill(ds, table);
            myDataAdapter.AcceptChangesDuringUpdate = true;
            myDataAdapter.Update(ds, table);
        }
