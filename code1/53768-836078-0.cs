    var results = (from data in db.SomeTable select data).ToArray();
    DataTable dt = ObjectArrayToDataTable(results);
    // At this point you have a properly structure DataTable.
    // Here is your XSD, if absolutely needed.
    dt.WriteXMLSchema("c:\somepath\somefilename.xsd");
    private static System.Data.DataTable ObjectArrayToDataTable(object[] data)
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        // if data is empty, return an empty table
        if (data.Length == 0) return dt;
        Type t = data[0].GetType();
        System.Reflection.PropertyInfo[] piList = t.GetProperties();
        foreach (System.Reflection.PropertyInfo p in piList)
        {
            dt.Columns.Add(new System.Data.DataColumn(p.Name, p.PropertyType));
        }
        object[] row = new object[piList.Length];
        foreach (object obj in data)
        {
            int i = 0;
            foreach (System.Reflection.PropertyInfo pi in piList)
            {
                row[i++] = pi.GetValue(obj, null);
            }
            dt.Rows.Add(row);
        }
        return dt;
    }
