    var query = _context.Instructors.AsQueryable();
    if (id.HasValue)
      query = query.Where(i => i.ID == id.Value);
    query = query.OrderBy(i => i.LastName);
    
    var instructors = await query.Select(i => new InstructorIndexData 
      {
        InstructorId = i.ID,
        // ...
        Courses = i.CourseAssignments.Select(ca => new CourseData {
          CourseId = ca.Course.ID,
          CourseName = ca.Course.Name,  
          //..
        }
      }).ToListAsync()
    
    if (courseId.HasValue)
    {
      var enrollments = await query.SelectMany(i => i.Courses.SingleOrDefault(c => c.CourseID == courseID.Value).Enrollments.Select(e => new EnrollmentData 
      {
        InstructorId = i.ID,
        EnrollmentId = e.EnrollmentID,
        CourseId = e.Course.CourseID,
        //...
      }).ToListAsync();
      
      // From here, group the Enrollments by Instructor ID and add them to the Instructor index data.
      var groupedEnrollments = enrollments.GroupBy(e => e.InstructorId);
      foreach(instructorId in groupedEnrollments.Keys)
      {
        var instructor = instructors.Single(i => i.InstructorId == instructorId);
        instructor.Enrollments = groupedEnrollments[instructorId].ToList();
      }
    }  
