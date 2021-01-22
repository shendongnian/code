    void PopulateListBox(ListBox listToPopulate)
    {
        SqlConnection conn = new SqlConnection("myConnectionString"); 
        SqlCommand cmd = new SqlCommand("spMyStoredProc", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string item = reader.GetString(0); //or whatever column is displayed in the list
            if (!item.Contains("OBJECT_"))
                listToPopulate.Items.Add(item); 
        }
    }
