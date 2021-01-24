    private void database_btn_updatedb_Click(object sender, EventArgs e)
        {
           
            Connection = new OleDbConnection(ConnectionString);
            DataSet changes = ds.GetChanges();
            try
            {
                Connection.Open();
                string SQL = "SELECT * FROM tbl_Jobs"; 
                OleDbDataAdapter oledbAdapterNEW = new OleDbDataAdapter(SQL, Connection); //new adapter with just jobs table ignoring customers for now
                OleDbCommandBuilder oledbCmdBuilderNEW = new OleDbCommandBuilder(oledbAdapterNEW); 
                   
                
                if (changes != null)
                {
                    oledbAdapterNEW.Update(ds,"tbl_Jobs");
                    MessageBox.Show("Jobs Save Changes");
                }
               
                SQL = "SELECT * FROM tbl_Customers";
                oledbAdapterNEW = new OleDbDataAdapter(SQL, Connection);
                oledbCmdBuilderNEW = new OleDbCommandBuilder(oledbAdapterNEW);
                if (changes != null)
                {
                    oledbAdapterNEW.Update(ds, "tbl_Customers");
                    MessageBox.Show("Customer Save Changes");
                }
                ds.AcceptChanges();
                Connection.Close();
            }
