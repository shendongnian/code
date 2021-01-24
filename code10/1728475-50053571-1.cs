    while (rdr.Read())
    {
        int promised_date = (int)(rdr.GetValue(0));
        string strClientName = (rdr.GetValue(1).ToString());
        string strClientReference = (rdr.GetValue(2).ToString());
        string strJobCategory = (rdr.GetValue(3).ToString());
        string datCommisioned = (rdr.GetValue(4).ToString());
        string datPromisedDelivery = (rdr.GetValue(5).ToString());
        if (this.OpenConnection() == true)//closing parenthesis
        {
            // query using parameter names 
            string querynew = "INSERT INTO jobs_table "
                              + "(nJobNumber,strClientName,strClientReference,strJobCategory,datCommisioned,datPromisedDelivery)" 
                              + "VALUES (@PromisedDate, @ClientName, @ClientReference, @JobCategory, @Commisioned, @PromisedDelivery)";
            MySqlCommand cmd = new MySqlCommand(querynew, connection);
            // add parameters and their value
            cmd.Parameters.AddWithValue("@PromisedDate", promised_date);
            cmd.Parameters.AddWithValue("@ClientName", strClientName);
            cmd.Parameters.AddWithValue("@ClientReference", strClientReference);
            cmd.Parameters.AddWithValue("@JobCategory", strJobCategory);
            cmd.Parameters.AddWithValue("@Commissioned", datCommissioned);
            cmd.Parameters.AddWithValue("@PromisedDelivery", datPromisedDelivery);
            cmd.ExecuteNonQuery(); 
            this.CloseConnection();
        }
    }
