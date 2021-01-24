    var then = DateTime.Now.AddDays(-7); //One portion of our Where. More below
    var sortedStudents = listOfStudents
      //Our predicate. 's' = the Student passed to the function. Give me only the students
      //where s.EnrollDate is greater or equal to the variable 'then' (defined above)
      .Where(s => s.EnrollDate >= then) 
      //We have no Select statement, so return whole students
      //And order them by their enrollment date in ascending order
      .OrderBy(s => s.EnrollDate);
