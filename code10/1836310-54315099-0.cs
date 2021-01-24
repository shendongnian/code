    public static IQueryable<Student> IncludeExpertise(this IQueryable<Student> students)
    {
        return subjects
            .Include(s => s.Expertise)
            .ThenInclude(c => c.Teacher)
            .ThenInclude(p => p.License);
        
    }
