    public DataTable MakeDataTable()
    {    
        DataTable table = new DataTable();    
        using (SqlConnection conn = new SqlConnection("ConnectionStringHere"))
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.Text = "SELECT * FROM MyTable";
                
                conn.Open();
        
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    table.load(rdr);
                }
            }
        }
        return table;  
    }
