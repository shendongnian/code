    var then = new DateTime.Parse("26 June 2018"); 
    var dates = listOfStudents
      .Where(s => s.EnrollDate >= then) 
      .Select(s => s.EnrollDate)
      .OrderBy(s => s.EnrollDate);
