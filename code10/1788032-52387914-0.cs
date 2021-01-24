    [Route("api/Students/GetProfile")]
    public StudentProfile GetProfile(string studentName)
    {
        //Code here
        return studentProfile;
    }
    [Route("api/Students/GetCourses")]
    public IEnumerable<Course> GetCourses(int studentId)
    {
        //Code here
        return courseList;
    }
