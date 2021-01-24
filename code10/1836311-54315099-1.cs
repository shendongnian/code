    public static IQueryable<Student> IncludeExpertise(this IQueryable<Student> students)
    {
        return students
            .Include(s => s.Expertise)
            .ThenInclude(c => c.Teacher)
            .ThenInclude(p => p.License);
        
    }
