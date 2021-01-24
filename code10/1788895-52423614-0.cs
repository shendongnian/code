    MySqlConnection myConn = new MySqlConnection(MySQLConn);
    MySqlCommand MySQLcmd = new MySqlCommand(Query, myConn);
    MySqlParameter priceParameter = new MySqlParameter("@price");
    MySQLcmd.Parameters.Add(priceParameter);
    
    using (myConn)
    {
        myConn.Open();
      
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
           var price = row.Cells["PRICE_COLUMN_NAME"].Value;
           
           MySQLcmd.Parameters["@price"].Value = price;
    
           MySQLcmd.ExecuteNonQuery();
         }
    }
