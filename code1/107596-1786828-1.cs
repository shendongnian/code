    public static List<StudentData> LinqDistinct(DataTable dt)
    {
        List<StudentData> results = dt.AsEnumerable()
            .GroupBy(row => 
            {
                FirstName = row.Field<string>("FirstName"),
                LastName = row.Field<string>("LastName")
            })
            .Select(group => new StudentData
            {
                FirstName = group.Key.FirstName,
                LastName = group.Key.LastName,
                Qty = group.Count()
            })
            .ToList();
        return results;
    }
    class StudentData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Qty { get; set; }
    }
