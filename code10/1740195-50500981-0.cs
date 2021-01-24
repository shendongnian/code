    foreach(ListViewItem ItemRow in this.listViewPOS.Items)
    {
                SQLConn.sqL = "INSERT INTO OrderDetails(ProductID, OrderID, SRP, Quantity, Discount, Total) VALUES('" + ItemRow.SubItems[0].Text + "'," +
                    "'" + OrderID + "', '" + ItemRow.SubItems[3].Text + "', '" + ItemRow.SubItems[4].Text + "', '" + ItemRow.SubItems[5].Text + "', '" + ItemRow.SubItems[6].Text + "')";
    
            SQLConn.ConnDB();
            SQLConn.cmd = new SqlCommand(SQLConn.sqL, SQLConn.conn);
            SQLConn.cmd.ExecuteNonQuery();
       }
