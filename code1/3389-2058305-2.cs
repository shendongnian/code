    DataTable contacts = dataSet.Tables["Contact"];    
    DataView view = contacts.AsDataView();    
    view.Sort = "LastName desc, FirstName asc";    
    bindingSource1.DataSource = view;
    dataGridView1.AutoResizeColumns();
