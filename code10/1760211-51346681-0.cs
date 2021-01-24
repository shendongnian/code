    DataTable contacts = dataSet.Tables["Contact"];
    
    EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                             where contact.Field<string>("LastName").StartsWith("S")
                                             orderby contact.Field<string>("LastName"), contact.Field<string>("FirstName")
                                             select contact;
    
    DataView view = query.AsDataView();
    
    bindingSource1.DataSource = view;
    dataGridView1.AutoResizeColumns();
