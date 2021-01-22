    DataTable dtblDataSource = new DataTable();
    dtblDataSource.Columns.Add("DisplayMember");
    dtblDataSource.Columns.Add("ValueMember");
    dtblDataSource.Columns.Add("AdditionInfo");
    
    dblDataSource.Rows.Add("Item 1", 1, "something useful 1");
    dblDataSource.Rows.Add("Item 2", 2, "something useful 2");
    dblDataSource.Rows.Add("Item 3", 3, "something useful 3");
    
    combo1.DataSource = dtblDataSource;
    combo1.DisplayMember = "DisplayMember";
    combo1.ValueMember = "ValueMember";
    
       //Get additional info
       foreach (DataRowView drv in combo2.Items)
       {
             string strAdditionInfo = drv["AdditionInfo"].ToString();
       }
       //Get additional info for selected item
        string strAdditionInfo = (combo1.SelectedItem as DataRowView)["AdditionInfo"].ToString();
    
       //Get selected value
       string strSelectedValue = combo1.SelectedValue.ToString();
