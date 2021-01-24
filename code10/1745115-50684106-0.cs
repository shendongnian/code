    public Course GetClassesByNameAndDate(string className, DateTime date, List<Courses> allCourses)
    {
        Course course  = allCourses
           .OrderBy( x => (x.StartDate - date).Duration() ) // use duration to turn negative TimeSpans into positive
           .First( x=> x.ClassName == className & x.StartDate <= date );
    }
