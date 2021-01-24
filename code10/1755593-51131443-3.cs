    bool valid1 = false;
    query6 = "SELECT DISTINCT Weight_Box FROM MO_spec WHERE PC = @pc";
    using(SqlCommand cmd6 = new SqlCommand(query6, con5)))
    {
        cmd6.Parameters.Add("@pc", SqlDbType.VarChar).Value = textBox1.Text;
        using(SqlDataReader dr1 = cmd6.ExecuteReader())
        {
             if(dr1.Read())
             {
                 w1 = Convert.ToSingle(dr1["Weight_Box"]);
                 valid1 = float.TryParse(textBox5.Text, out a1);
             }
        } 
        // Closing the reader here allows the following query without
        // MultipleActiveRecordset active in your connectionstring
        if(valid1)
        {
             // the remainder of your code goes here.
             // Inside proper using blocks and with the correct parameters
        }
 
    }
