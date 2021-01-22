    // dgvBill is name of DataGridView
    string StrQuery;
    try
    {
        using (SqlConnection conn = new SqlConnection(ConnectingString))
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = conn;
                conn.Open();
                for (int i = 0; i < dgvBill.Rows.Count; i++) 
                {
                    StrQuery = @"INSERT INTO tblBillDetails (IdBill, productID, quantity, price,  total) VALUES ('" + IdBillVar+ "','" + dgvBill.Rows[i].Cells[0].Value + "', '" + dgvBill.Rows[i].Cells[4].Value + "', '" + dgvBill.Rows[i].Cells[3].Value + "', '" + dgvBill.Rows[i].Cells[2].Value + "');";
                    comm.CommandText = StrQuery;
                    comm.ExecuteNonQuery();         
                 }
             }
         }
     }
     catch (Exception err)
     {
         MessageBox.Show(err.Message  , "Error !");
     }
