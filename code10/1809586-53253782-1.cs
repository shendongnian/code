    using (var context = new MyContext())
    {
      var courseIds = context.Courses
        .Where(c => c.CourseName.StartsWith(searchText))
        .ToList();
    
      var query = context.Students
        .Where(s => s.Courses.Any(c => courseIds.Contains(c.CourseId)));
    
      var viewModels = query.SelectMany( s => s.Courses.Where(c => courseIds.Contains(c.CourseId))
        .Select(c => new ScheduleVM 
        {
          StudentName = s.StudentName,
          IndexNumber = s.IndexNumber,
          CourseName = c.CourseName
        })).ToList()
    }
