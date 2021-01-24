    using (dbEntities entities = new dbEntities())
    {
        var db = entities.db_table
        .GroupBy(x => x.ID) //grouping by the id
        .Select(x => x.OrderByDescending(y => 
                     y.REVISIONID).FirstOrDefault()).ToList();
       return db.OrderBy(e => DateTime.Parse(e.Date_String)).ToList(); 
    }
