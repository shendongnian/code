    var mySqlQuery = "SELECT * FROM purchase_order WHERE purchase_order_number LIKE '" + cmbPurchaseOrderNumbers.Text + "'";
    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();
        using (var command = new MySqlCommand(mySqlQuery, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                //Iterate through the rows and add it to the combobox's items
                while (reader.Read())
                {
                    lblPoNumber.Text = reader.GetString("purchase_order_number");
                    cmbBillTo.Text = reader.GetString("purchase_order_bill_to");
                    cmbShipTo.Text = reader.GetString("purchase_order_ship_to");
                    cmbWareHouse.Text = reader.GetString("purchase_order_location");
                    cmbVendors.Text = reader.GetString("purchase_order_vendor");
                    txtPoDate.Text = reader.GetDateTime().ToString("yyyy-MM-dd hh:mm:ss"); 
    
                }
            }
        }
    }
