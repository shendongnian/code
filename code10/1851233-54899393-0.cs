    DataTable dt = new DataTable();
    
    DataColumn c = new DataColumn("FirstName");
    dt.Columns.Add(c);
    
    DataRow r = dt.NewRow();
    r["FirstName"] = model.FirstName; // model is an instance of Employee_Master_Model
