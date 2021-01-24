    using (SqlConnection cn = new SqlConnection(conString))
    {
         using (SqlCommand cmd = new SqlCommand(sqlString, cn))
         {
            try 
            {
                cn.Open();
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    // check if the reader returns result set
                    if (read.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(read);
                        this.tblBankDataGridViewX.DataSource = dt;
                    }
    
                }
            }
            catch (Exception ex)
            {
                // do something
            }
         }
    }
