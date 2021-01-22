    using (DataSet ds = yourcall()) 
    {
      if (ds.HasRows())
      {
         foreach (DataRow dr in ds.Tables[0].Rows)
         {
            int id = dr.Field<int>("ID");
            string name = dr.Field<string>("Name");
            string Action = dr.Field<string>("Action", "N/A");
         }
      }
    }
