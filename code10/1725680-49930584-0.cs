    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = @"SELECT ShipDate FROM [ProductTracking] WHERE ID= @ProductID;UPDATE [ProductTracking] SET ShipDate = current_timestamp, ScanQty = coalesce(ScanQty,0) + 1 WHERE ID= @ProductID";
        using (var connection = new SqlConnection(GetConnectionString()))
        using (var command = new SqlCommand(sql, connection))
        {
            command.Parameters.Add("@ProductID", SqlDbType.Int).Value =  TextBox1.Text;
            connection.Open();
            using (SqlDataReader rdr = command.ExecuteReader())
            {
               if (!rdr.Read())
               {
                   pageBody.Attributes.Add("bgcolor", "#ff8e8e");
                   Label1.Text = "Item " + TextBox1.Text + " Not Found!";
               }
               else if (rdr["ShipDate"] == DBNull.Value)
               {
                    pageBody.Attributes.Add("bgcolor", "#9aff8e");
                    Label1.Text = "Item " + TextBox1.Text + " Recorded!";
               }
               else
               {
                   pageBody.Attributes.Add("bgcolor", "#fbff8e");
                   Label1.Text = "Item " + TextBox1.Text + " Already Shipped!";                 
               }
               rdr.Close();
            }
        }
        TextBox1.Text = "";
    }
