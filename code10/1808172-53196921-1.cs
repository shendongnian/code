    //Create a new course or as many as you wish and fill the model class with data.
    Course mathCourse = new Course()
    {
    	CourseName = "Math",
    	Faculties = new List<Faculty>(),
    	Students = new List<Student>()
    ;
    mathCourse.Faculties.Add(new Faculty("Faculty for math Alpha"));
    mathCourse.Faculties.Add(new Faculty("Faculty for math Beta"));
    mathcourse.Students.Add(new Student("Ben"));
    
    //create as many different courses as you want and at them to your list you've created.
    course.Add(mathCourse);
    
    //you can now reach the faculty in the course like this
    //We select with [0] the first course in the courseList, then we select the first faculty of the course with [0] and select its property 'name'.
    //This goes for any property as long the class Faculty is public and its property is too.
    string facultyName = course[0].Faculties[0].Name;
    
    //>> facultyName => Faculty for math Alpha  
