    while (dr.Read())
    {
         string firstItem = Convert.ToString(dr["FIRST_ITEM"]);
         if(!string.IsNullOrEmpty(firstItem))
         {
            machineName.Items.Add(firstItem);
         }
         ... etc.
    }
