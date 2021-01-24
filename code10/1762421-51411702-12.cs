    var results = db.Group
        .Where(g => g.IsActive)
        .Join(
            db.Section.Where(s => s.IsActive),
            g => g.Id,
            s => s.GroupId,
            (g, s) => new
            {
                Group = g,
                UserSection = new
                {
                    Section = s,
                    UserCourses = db.Course.Where(c => c.IsActive && c.UserId == _userId && c.SectionId == s.Id).DefaultIfEmpty()
                }
            })
        .ToList() // Data gets fetched from database at this point
        .GroupBy(x => x.Group) // In-memory grouping
        .Select(x => new
        {
            Group = x.Key,
            UserSections = x.Select(us => new
            {
                Section = us.UserSection,
                UserCourses = us.UserSection.UserCourses
            })
        });
