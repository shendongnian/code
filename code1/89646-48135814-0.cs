    DataTable dt = new DataTable();
    dt.Columns.Add("Id", typeof(string));
    dt.Columns.Add("Name", typeof(string));
    dt.Rows.Add("1", "test");
    //populate selectlist with DataTable dt
    var selectList = new SelectList(dt.AsDataView(), "Id", "Name");
