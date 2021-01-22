    from p in context.ProfessorSet
    from s in p.Student
    group s by s.StudentId into g
    select new
    {
        Professor = p,
        StudentCounts = from sc in g
                        select new
                        {
                            StudentId = sc.Key,
                            Count = sc.Count()
                        }
    }
