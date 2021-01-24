    adapter.SelectCommand = cmd;
    System.Data.DataTable dtCategories = new System.Data.DataTable();
    adapter.Fill(dtCategories);
    
    comboBoxCategory.ValueMember = "Category_Desc";
    comboBoxCategory.DisplayMember = "Category_Desc";
    comboBoxCategory.DataSource = dtCategories;
