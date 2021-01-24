    IQueryable<Student> studentIQ = _context.Students.Include(st => st.Enrollments).ThenInclude(enr => enr.Course).ToList();
    if (!String.IsNullOrEmpty(searchString))
    {
        studentIQ = studentIQ
       .Where(
                 s => s.Enrollments
                       .Any(enr => enr.Course.Title.Equals(searchString)
             )
    }
