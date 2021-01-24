    string clientName = "my client";
    string project = null;
    DataTable data3 = new DataTable();
    var listData = data3.AsEnumerable().Where(m => 
        (String.IsNullOrEmpty(clientName) || m.Field<string>("clientname") == clientName)
        && (String.IsNullOrEmpty(project) || m.Field<string>("project") == project)
    ).Select(row => new Project()
    {
        clientname = row.Field<string>("clientname"),
        project = row.Field<string>("project"),
        postedstate = row.Field<string>("postedstate"),
        postedcity = row.Field<string>("postedcity"),
        siteadd = row.Field<string>("siteadd")
    }).Distinct();
