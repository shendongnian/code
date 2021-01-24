    if (dt.Rows.Count > 0)
    {
        dt = dt.AsEnumerable().OrderByDescending(x=>x.Field<decimal>("Hotel Costs")).ThenByDescending(x=>x.Field<decimal>("Flight Costs"))
        .Select(x=>
            x.Field<Column1's DataType>("Column Ones Name"),
            x.Field<column2's DataType>("Column Twos Name"),
            ..and so on)//repeat this for all the columns you want
        .CopyToDataTable();
    }
