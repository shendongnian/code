    var unstructured = classRooms
       .SelectMany(c=> c.Teachers.Select( t=> new {
          Title = c.Title,
          SessionsPerRoom = c.NoSessions,
          Teacher = t.Teacher,
          SessionsPerTeacher = t.NoSessions
       });
