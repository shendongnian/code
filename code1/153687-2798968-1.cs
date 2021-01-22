    Dictionary<string, string> dict = new Dictionary<string, string>();
    dict.Add("foo", "bar");
    //translate and bind
    DataTable dt = new DataTable();
    dt.Columns.Add("Key", typeof(string));
    dt.Columns.Add("Value", typeof(string));
    dict
        .ToList()
        .ForEach(kvp => dt.Rows.Add(new object [] {kvp.Key,kvp.Value}));
    
    //allows you to add uniqueness constraint to the key column :-)
    dt.Constraints.Add("keyconstraint", dt.Columns[0], true);
    
    myDataGridView.DataSource = dt;
