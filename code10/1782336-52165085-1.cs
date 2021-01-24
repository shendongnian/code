      public void Insert_Data_generic(DataSet dsins)
      {
            SqlConnection con = new SqlConnection(connectionstring);
            string Result = "insert into TableName (";
            SqlCommand cmd = new SqlCommand();    
            con.Open();
            string columns = string.Join(",", dsins.Tables[0].Columns.Cast<DataColumn>().Select(c => c.ColumnName));
            string values = string.Join(",", dsins.Tables[0].Columns.Cast<DataColumn>().Select(c => string.Format("@{0}", c.ColumnName)));
            Result += columns + ") values(" + values + ")";
            foreach (DataRow row in dsins.Tables[0].Rows)
            {
                cmd = new SqlCommand(Result, con);
                cmd.Parameters.Clear();
                foreach (DataColumn col in dsins.Tables[0].Columns)
                {
                    cmd.Parameters.AddWithValue("@" + col.ColumnName, row[col]);
                }
                cmd.ExecuteNonQuery();
            }
         }
