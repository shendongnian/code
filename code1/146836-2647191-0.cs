    public static List<object> GetStudents()
    {
        DojoDBDataContext conn = new DojoDBDataContext();
    
        var query =
            (from s in conn.Students
             select new
             {
                 ID = s.ID,
                 FirstName = s.FirstName,
                 LastName = s.LastName,
                 Belt = s.Belt
             }).Cast<object>().ToList();
    
        return query;
    }
