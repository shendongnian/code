    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    
    SqlConnection conn = new SqlConnection(CS);
        conn.Open();
        string query = "Select * from tblProductInventory";
        
        SqlCommand cmd = new SqlCommand(query, conn);
        
        DataTable t1 = new DataTable();
        using (SqlDataAdapter a = new SqlDataAdapter(cmd))
        {
            a.Fill(t1);
        }
        
        dataGridView1.DataSource = t1;
