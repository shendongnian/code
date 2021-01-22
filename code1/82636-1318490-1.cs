    IEnumerable<DataRow> query = tempResults.AsEnumerable();
    if(!string.IsNullOrEmpty(value1)) {
        query = query.Where(row => row.Field<string>("Col1") == value1);
    }
    if (!string.IsNullOrEmpty(value2)) {
        query = query.Where(row => row.Field<string>("Col2") == value2);
    }
