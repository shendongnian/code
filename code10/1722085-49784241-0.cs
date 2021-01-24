    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var counter = 0;
        var query = @"insert into Stock_Take_Item
                      (ItemID, BarQuantity, StorageQuantity)
                      values
                  ({1}, {2}, {3});
                   insert into Stock_Take
                   (Username, StockDate) 
                   values
                   ({0}, GetDate());";
      
        var paramList = new List<SqlParameter>();
        var sqlBulk = new StringBuilder(10000);
        var p0 = "@0";
        var maxRows = 100;
        var currRow = 0;
        var totalRows = 0;
        foreach (GridViewRow row in gvStockTake.Rows)
        {
            Label ID = row.FindControl("itemId") as Label;
            TextBox BAR = row.FindControl("txtBar") as TextBox;
            TextBox STORAGE = row.FindControl("txtStorage") as TextBox;
        
            currRow++;        
            totalRows++;
            if (counter == 0)
            {
                paramList.Add(new SqlParameter(, Session["username"].ToString()));            
            }
            var p1 = "@" + ++counter;
            var p2 = "@" + ++counter;
            var p3 = "@" + ++counter;
        
            paramList.AddRange(new[]{
                new SqlParameter(p1, Convert.ToInt32(Id.Text),
                new SqlParameter(p2, Convert.ToInt32(BAR.Text),
                new SqlParameter(p3, Convert.ToInt32(STORAGE.Text)
                });
            sqlBulk.AppendFormat(query, p0, p1, p2, p3);
            if (currRow == maxRows || totalRows == gvStockTake.Rows)
            {
                using (var con = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand(sqlBulk.ToString(), con))
                    {
                        cmd.Parameters.AddRange(paramList);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                currRow = 0;
                counter = 0;
                paramList.Clear();
                sqlBulk.Length = 0;
            }
       
        }
    }
