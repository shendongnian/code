        public void ConnectListAndSaveSQLCompactExample()
        {
            // Create a connection to the file datafile.sdf in the program folder
            string dbfile = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\datafile.sdf";
            SqlCeConnection connection = new SqlCeConnection("datasource=" + dbfile);
            // Read all rows from the table test_table into a dataset (note, the adapter automatically opens the connection)
            SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from test_table", connection);
            DataSet data = new DataSet();
            adapter.Fill(data);
            // Add a row to the test_table (assume that table consists of a text column)
            data.Tables[0].Rows.Add(new object[] { "New row added by code" });
            // Save data back to the databasefile
            adapter.Update(data);
            // Close 
            connection.Close();
        }
