    var info = new <your object with data>;
    // Add by reflection
    Type t = info.GetType();
    var row = new object[t.GetProperties().Length];
    int index = 0;
    foreach (PropertyInfo p in t.GetProperties())
    {
        row[index++] = p.GetValue(info, null);
    }
    this.dataTable.Rows.Add(row);
