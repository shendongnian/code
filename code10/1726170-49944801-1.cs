    Public List<Items> Get(string sql)
    {
    
     using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            var  ItemsList = new List<Items>();
            var Items = new Items()
            SqlCommand command = new SqlCommand(sql, connection);       
            SqlDataReader dr = command.ExecuteReader();
            dr = cmd.ExecuteReader();
    
            while (dr.Read())
            {
                   Items.ItemID  = dr["ItemID"].ToString();
                   Items.ItemName = dr["ItemName"].ToString();                        
                   Items.ItemPlace = dr["ItemPlace"].ToString();
                   ItemsList.Add(Items);
            }
            
            if(ItemsList.Count == 0)
              {
                 Items.ItemID = null;
                 Items.ItemName = null;
                 Items.ItemPlace = null;
                 ItemsList.Add(Items);
              }
                         
            return ItemsList;
        } 
    }
