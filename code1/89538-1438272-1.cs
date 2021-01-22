    public IEnumerable<Course> Courses
    {
        get { return CourseRepository.GetCoursesByStudentId(this.Student_Id); }
    }
    //Aggregate course names into a comma-separated list
    public string CoursesDescription 
    {
        get 
        {
            if (!Courses.Any())
                return "Not enrolled in any courses";
           
            return Courses.Aggregate(string.Empty, (currentOutput, c) =>
                  (!String.IsNullOrEmpty(currentOutput)) ?
                  string.Format("{0}, {1}", currentOutput, c.Course_Name) :  c.Course_Name );
        }  
    }
