    public static List<Course> GetCoursesByTeacher(string lastName)
    {
        using (var context = new Context())
        {
            var result = context.Teachers.Where(cb => cb.lastName == lastName).ToList();
        }
    }
