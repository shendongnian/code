    var students = _context.Students
                        .Where(s => s.Id == 2)
                        .ToList()
                        .Select(student => new
                        {
                            LatestGrade = student.Grades.OrderBy(g => g.Date).FirstOrDefault(),
                            Id = student.Id
                        })
                        .ToList();
