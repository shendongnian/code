    var output = dataTable.Rows.Cast<DataRow>().Select(r => new 
        {
           alias1 = r["Column1"].ToString(),
           alias2 = r["Column2"].ToString(),
           alias3 = r["Column3"].ToString(),
           /// etc...
        });
