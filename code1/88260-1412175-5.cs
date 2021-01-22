    DataTable table = new DataTable();
    table.Columns.Add("MembershipId", typeof(int));
    table.Columns.Add("UserName");
    table.Columns.Add("Password");
    List<SomeMemberClass> list = new List<SomeMemberClass>(); //or get the list from somewhere else...
    var differntIds = list.Select( s => s.DifferentId).Distinct();
    var result = table.AsEnumerable()
                          .Where( dt => differntIds
                          .Contains((int)dt["MembershipId"]))
                          .CopyToDataTable();
