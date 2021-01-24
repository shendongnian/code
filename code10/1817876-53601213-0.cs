    void PopulateGridView(string searchTerm)
    {
        DataTable dtbl = new DataTable();
        using (OleDbConnection sqlCon = new OleDbConnection(connectionStr))
        {
            string query = "SELECT * FROM Users";
    
           OleDbCommand sqlCmd = new OleDbCommand(query, sqlCon);
    
           if(!String.IsNullOrWhiteSpace(searchTerm)) {
                     query+=" WHERE UserName=@UserName";
                     sqlCmd.CommandText = query;
                    sqlCmd.Parameters.AddWithValue("@UserName", txtUserNameFooter.Text);
             }
            
            sqlCon.Open();
            OleDbDataAdapter sqlDa = new OleDbDataAdapter(sqlCmd);
            sqlDa.Fill(dtbl);
        }
    
        if (dtbl.Rows.Count > 0)
        {
            AdminBook.DataSource = dtbl;
            AdminBook.DataBind();
        }
        else
        {
            dtbl.Rows.Add(dtbl.NewRow());
            AdminBook.DataSource = dtbl;
            AdminBook.DataBind();
            AdminBook.Rows[0].Cells.Clear();
            AdminBook.Rows[0].Cells.Add(new TableCell());
            AdminBook.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            AdminBook.Rows[0].Cells[0].Text = "No Data Found";
            AdminBook.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }
    }
