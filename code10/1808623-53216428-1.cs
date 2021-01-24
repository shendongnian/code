    if (words[0] == "Course")
    {
       string nameOfCourse = words[1];
       currentCourse++;
       courses[currentCourse] = new Course
       {
          Name = nameOfCourse
       };
    }
    if (words[0] == "Faculty")
    {
        string firstName = words[1];
        string lastName = words[2];
        string numOfClasses = words[3];
        courses[currentCourse].FacultyMems.Add(new Faculty
        {
            FirstName = firstName,
            LastName = lastName,
            NumOfClasses = numOfClasses,
        });
    }
    if (words[0] == "Student")
    {
        string firstName = words[1];
        string lastName = words[2];
        string numOfClasses = words[3];
        courses[currentCourse].Students.Add(new Student
        {
            FirstName = firstName,
            LastName = lastName,
            NumOfClasses = numOfClasses,
        });
    }
