    public Course GetClassesByNameAndDate(string className, DateTime date, List<Courses> allCourses)
    {
        Course course  = allCourses.Where( x >= x.ClassName == className && x.StartDate => date && x.EndDate.HasValue ? x.EndDate.Value <= date : true).FirstOrDefault();
    
    }
