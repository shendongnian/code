    // Move part of the Where clause to the database query and load all the relevant data
    var studentMessages = context.Students
      .Include(x => x.student.Include)
      .Include(x => x.message)
      .Where(s => s.SchoolId == SchoolId 
                  && x.student.Status != (int)StudentStatusEnum.NotActive)) 
      .ToArray();
    // Get two relevant groups (one with message set, the other without)
    var studentsByMessageNotNull = (from x in studentMessages
      group x by (x.message != null) into g
      select new { HasMessage = g.Key, Students = g.ToArray() })
      .ToArray();
    // Prepare block for students without message
    var studentsWithoutMessage = studentsByMessageNotNull
      .Where(x => !x.HasMessage)
      .SelectMany(x => x.Students)
      .OrderBy(x => x.user.Id)
      .ToArray();
    // Prepare block for students with message
    var studentsWithMessage = studentsByMessageNotNull
      .Where(x => x.HasMessage)
      .SelectMany(x => x.Students)
      .OrderBy(x => x.message.NextFollowUpDate)
      .ToArray();
    // Concat the blocks
    var sSorted = studentsWithoutMessage
      .Concat(studentsWithMessage)
      .Concat(studentsWithMessage)
      .Concat(studentsWithoutMessage)
      .ToArray();
    var allStudents = (isSelectAll == true ? sSorted  : sSorted .Skip(skipNumber).Take(query.AmountEachPage)).ToArray();
      
