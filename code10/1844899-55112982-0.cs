        public DataSet SelectDset()
        {
            DataTable dtTablesNames=new DataTable();      
            try
            {
                Open();
                //get the list of tables in the database into a DataTable
                sTablesNamesQuery="SELECT TABLE_NAME FROM INFORMATION_SCHEMA.Tables WHERE TABLE_TYPE = 'BASE TABLE' Order by TABLE_NAME";
                SqlDataAdapter sda1 = new SqlDataAdapter(sTablesNamesQuery, con);
				sda1.Fill(dtTablesNames);
                //               
                DataSet dsAllTables = new DataSet();
                StringBuilder sbQuery = "";
                //build the queries that will be used to retrieve the tables rows
                foreach (DataRow dr in dtTablesNames.Rows)
                {
                    sbQuery.Append("SELECT * FROM " + dr["TABLE_NAME"].ToString()+";");                    
                }
                //
                SqlDataAdapter sda2 = new SqlDataAdapter(sbQuery, con);
                sda2.Fill(dsAllTables);
                sda1.Dispose();
                sda2.Dispose();
                Close();
                return dsAllTables;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
       }
 
