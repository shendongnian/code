    DataTable dtblDataSource = new DataTable();
    dtblDataSource.Columns.Add("DisplayMember");
    dtblDataSource.Columns.Add("ValueMember");
    dtblDataSource.Columns.Add("AdditionalInfo");
    
    dtblDataSource.Rows.Add("Item 1", 1, "something useful 1");
    dtblDataSource.Rows.Add("Item 2", 2, "something useful 2");
    dtblDataSource.Rows.Add("Item 3", 3, "something useful 3");
    
    combo1.Items.Clear();
    combo1.DataSource = dtblDataSource;
    combo1.DisplayMember = "DisplayMember";
    combo1.ValueMember = "ValueMember";
    
       //Get additional info
       foreach (DataRowView drv in combo1.Items)
       {
             string strAdditionalInfo = drv["AdditionalInfo"].ToString();
       }
       //Get additional info for selected item
        string strAdditionalInfo = (combo1.SelectedItem as DataRowView)["AdditionalInfo"].ToString();
    
       //Get selected value
       string strSelectedValue = combo1.SelectedValue.ToString();
