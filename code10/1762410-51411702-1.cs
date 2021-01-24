    var results = db.Group
        .Where(g => g.IsActive)
        .GroupJoin(
            db.Section.Where(s => s.IsActive),
            g => g.Id,
            s => s.GroupId,
            (g, s) => new
            {
                Group = g,
                UserSections = s
                    .GroupJoin(
                        db.Course.Where(c => c.IsActive && c.UserId == _userId).DefaultIfEmpty(),
                        ss => ss.Id,
                        cc => cc.SectionId,
                        (ss, cc) => new
                        {
                            Section = ss,
                            UserCourses = cc
                        }
                    )
            })
        .ToList();
