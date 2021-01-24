    Course aCourse = new Course();
    for(int i =0; i<numberOfCourses;i++)
    {
        //writer.WriteLine(courses.ToString());
        writer.WriteLine("{0}{1}{2}{1}{3}{1}{4}", aCourse.CourseCode, Delim, aCourse.Name, aCourse.Description, aCourse.NoOfEvaluations);
    }
