    public static List<StudentData> LinqDistinct(DataTable dt)
    {
        DataTable linqTable = dt;
        return
            (from names in dt.AsEnumerable()
             select new {
                 FirstName = names.Field<string>("FirstName"),
                 LastName = names.Field<string>("LastName")
             }).Distinct().Select(x =>
                 new StudentData() { FirstName=x.FirstName, LastName=x.LastName})
                 .ToList();
    }
