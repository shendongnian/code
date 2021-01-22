    // iterate over the rows of the datatable
    foreach (var row in table.AsEnumerable())  // AsEnumerable() returns IEnumerable<DataRow>
    {
        var id = row.Field<int>("ID");                           // int
        var name = row.Field<string>("Name");                    // string
        var orderValue = row.Field<decimal>("OrderValue");       // decimal
        var interestRate = row.Field<double>("InterestRate");    // double
        var isActive = row.Field<bool>("Active");                // bool
        var orderDate = row.Field<DateTime>("OrderDate");        // DateTime
    }
