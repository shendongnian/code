    DataTable dt = dataSet1.Tables["codes"];
    codesTableAdapter.InsertQuery(txtCode.Text,txtName.Text); 
    codesTableAdapter.Fill(dt); 
    // Add a new row to your datatable;
    DataRow dr = dt.NewRow();
    dr["ID"] = 100;
    dr["Value"] = "This is my value";  // this is assumeing the 'Value' columns is of type string.
    dt.Rows.Add(dr);
    
    codesTableAdapter.Update(dataSet1); 
    dataSet1.AcceptChanges(); 
