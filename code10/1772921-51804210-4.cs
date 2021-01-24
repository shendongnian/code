    SqlDataReader dr = sqlCmd.ExecuteReader();
    int cat_next_code = 0;
    if(dr.Read()) // while is not needed here. There will be only one row in the reader as per the query.
    {
         i = 1;
         if(!dr.IsDBNull(0))
         {
             cat_next_code = int.Parse(dr[0].ToString());
         }
     }
     Ctgry_CtgryCodeCb.Text = (cat_next_code + 1).ToString();
                    
