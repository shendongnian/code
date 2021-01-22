    string stdInfo = string.Empty;
    string studentId = txtStudentID.Text;
    using (var db = new CourseDataContext())
    {
        Student student = (
            from student in db.Students
            where student.StudentID == studentId
            select student).Single();
        stdInfo += string.Format("Student {0} {1}:\nTaking Courses:",
            student.FirstName, student.LastName);
        var courseNames =
            from taken in student.TakesCourses
            select taken.Course.CourseName;
        foreach (string courseName in courseNames)
        {
            stdInfo += string.Format("\nCourse: {0}", courseNames);
        }
    }
    MessageBox.Show(stdInfo);
