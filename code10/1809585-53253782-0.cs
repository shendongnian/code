    using (var context = new MyContext())
    {
      var courseIds = context.Courses
        .Where(c => c.CourseName.StartsWith(searchText))
        .ToList();
    
      var query = context.Students
        .Where(s => s.Courses.Any(c => courseIds.Contains(c.CourseId)));
    }
