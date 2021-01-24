    private void DateReturn2_ValueChanged(object sender, EventArgs e)
     {
        using (var con = SQLConnection.GetConnection())
        {
             using (var select = new SqlCommand("Select * from Purchase_Return where Date between @date1 and @date2", con))
            {
                select.Parameters.AddWithValue("@date1", DateReturn1.Value);
                select.Parameters.AddWithValue("@date2", DateReturn2.Value);
    
                using (var sd = new SqlDataAdapter(select))
                {                    
                    DataTable newDT= new DataTable();
                    sd.selectcommand = select;
                    sd.fill(newDT);
                    //PurchaseReturn.DataSource = null;
                    PurchaseReturn.DataSource = newDT;        
                }
            }
        }
     }
