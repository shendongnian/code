    private void PopulateCombo()
    {
       // get data view that returns 3 columns, 
       //master sort column set to 1, id, and description //
      DataView view = GetSource();
      // add a new row to the data source that has column values
      // 0 for master sort column (all others are returned 1
      // an appropriate ID and a description
      // data view columns = master sort column, id, description	
      view.Table.Rows.Add(new object[] {0, 1, "MasterValue"});
      // sort first by master column then description //
      view.Sort = "MasterSortColumn ASC, Description ASC"; 
    
      combo.DataSource = view;
      combo.ValueMember = "Id";
      combo.DisplayMember = "Description";
    }
