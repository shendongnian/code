    Dictionary<int, Course> Courses = new Dictionary<int, Course>();
    ...
    addStudentToClass()
    {
        Console.Write("Please enter the student's ID: ");
        string studentInput = Console.ReadLine();
        int studentID = Convert.ToInt32(studentInput);
        Console.Write("Please enter the course ID: ");
        string courseInput = Console.ReadLine();
        int courseID = Convert.ToInt32(courseInput);
        Courses[courseID].studentList.Add(Students.current[studentID]);
    }
