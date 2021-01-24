     protected void btnAdd_Click(object sender, ImageClickEventArgs e)
     {
        int rowTotal = Int32.Parse(totalRow.Text);
        int i = 0;
        panelTest.Visible = true;
    
        dtTemp();
        DataRow dr = TempTable.NewRow();
    
        for (; ; )
        {
            if (i < rowTotal)
            {
                dr = TempTable.NewRow();
                dr["ID_"] = "";
                dr["Name_"] = "";
                dr["Phone_"] = "";
                TempTable.Rows.Add(dr);
                grid1.DataSource = TempTable;
                grid1.DataBind();
            }
            else
            {
                break;
            }
            
            i++;
        }
    }
