     using (SqlConnection connection = new SqlConnection())
     using (SqlCommand cmd = new SqlCommand())
     {
         connection.Open();
     }
     catch(Exception ex)
     {
         // Is connection valid? Is cmd valid?  how would you tell?
         // if the ctor of either throw do I get here?
     }
