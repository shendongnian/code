    DataSet dset = new DataSet();
    
    DataTable dtable = new DataTable("OutputTable");
    dtable.Columns.Add(new DataColumn("Name",typeof(string)));
    dtable.Columns.Add(new DataColumn("Value", typeof(int)));
    dtable.Columns.Add(new DataColumn("Key", typeof(string)));
    
       
    //do a foreach or any other operation here
    //you can add a new row to the datatable like that: 
    drow["Name"] = "10001";
    drow["Value"] = 3;
    drow["Key"] = "A103";
    DataRow drow = dtable.NewRow();
    dtable.Rows.Add(drow);
    
    //after adding ALL rows, you have to add the datatable to the dataset
    dset.Tables.Add(dtable);
