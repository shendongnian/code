    DataTable contacts = dataSet.Tables["Contact"];
    
    DataView view = contacts.AsDataView();
    
    view.RowFilter = "LastName='Zhu'";
    
    bindingSource1.DataSource = view;
    dataGridView1.AutoResizeColumns();
