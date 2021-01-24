      while (dr.Read())
      {
         int? Apvl_Lvl_Value;
         // Check if the value of the column with the ordinal Apvl_Lvl_Id is DBNull
         if(dr.IsDBNull(Apvl_Lvl_Id))
         {
           // If so, use .NET "null" for the rest of the logic.
           Apvl_Lvl_Value = null;
         }
         else
         {
            // Use the actual columns (non-NULL) value.
            Apvl_Lvl_Value = dr.GetInt32(Apvl_Lvl_Id);
         }
         // Do something with the column's value, stored in Apvl_Lvl_Value
      }
