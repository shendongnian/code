    SqlCommand com2 = new SqlCommand();
    com2.Connection = con;
    com2.CommandText = @"INSERT INTO Purchase_Order_Detail (P_Order_ID,ProductID,PSC_ID,Pack_ID,Color,Base_ID,Quantity) VALUES (@OrderID,@ProductID,@Sub_ID, @PackID,@Colors,@BaseID,@Quantity);";
    com2.Parameters.Add("@OrderID", ...type...);
    com2.Parameters.Add("@ProductID", ...type...);
    com2.Parameters.Add("@Sub_ID", ...type...);
    com2.Parameters.Add("@PackID", ...type...);
    com2.Parameters.Add("@Colors", ...type...);
    com2.Parameters.Add("@BaseID", ...type...);
    com2.Parameters.Add("@Quantity", ...type...);
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        foreach (DataRow dr2 in dt.Rows)
        {
            OrderID = Convert.ToInt32(dr2["P_Order_ID"].ToString());
        }
        com2.Parameters["@OrderId"].Value = OrderId;
        com2.Parameters["@ProductID"].Value = dataGridView1.Rows[i].Cells[4].Value;  
        ...        
      
        com2.ExecuteNonQuery();
    }
