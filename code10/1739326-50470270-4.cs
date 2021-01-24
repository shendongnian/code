    DataTable result = GetDataTable();
    var dic  = result.AsEnumerable().ToDictionary(r => new { A = r.Field<string>("A"), D = r.Field<string>("D")});
    while (reader.Read())
    {
        var a = reader.Field<int>("a").ToString();
        var b = reader.Field<int>("b").ToString();
        var c = reader.Field<double>("c");
        var d = reader.Field<string>("d");
        var e = reader.Field<string>("e");
     
        DataRow datarow;
        if(!dic.TryGetValue(new{A = a, D = d}, out datarow))
        {
            datarow = result.NewRow();
            datarow["A"] = a;
            datarow["D"] = d;
            datarow["E"] = e;
            result.Rows.Add(datarow);
            dic.Add(new{A = a, D = d}, datarow);
        }
        datarow[b] = c;
    }
    return result;
