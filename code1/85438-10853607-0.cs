     if (Convert.IsDBNull(reader["DecimalColumn"]))
         {
            decimalData = 0m;
         }
         else
         {
            decimalData = reader.GetDecimal(reader.GetOrdinal("DecimalColumn"));
         }
