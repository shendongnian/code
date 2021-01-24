    private void DateReturn2_ValueChanged(object sender, EventArgs e)
     {
        using (var con = SQLConnection.GetConnection())
        {
            using (var select = new SqlCommand("Select * from Purchase_Return where Date between '" + DateReturn.Value.ToString() + "' and '" + DateReturn2.Value.ToString() + "'", con))
            {
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
