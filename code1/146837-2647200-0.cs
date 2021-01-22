    public static IEnumerable<Object> GetStudents()
    {
        DojoDBDataContext conn = new DojoDBDataContext();
    
        return conn.Students
                   .Select(s => new {
                       ID = s.ID,
                       FirstName = s.FirstName,
                       LastName = s.LastName,
                       Belt = s.Belt 
                   });
    }
