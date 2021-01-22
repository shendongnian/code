    public static List<StudentData> LinqDistinct(DataTable dt)
    {
        return dt.AsEnumerable()
                 .Select(row => new StudentData
                                {
                                    FirstName = row.Field<string>("FirstName"),
                                    LastName = row.Field<string>("LastName"),
                                    Qty = row.Field<int>("Qty")
                                })
                 .Distinct()
                 .ToList();
    }
