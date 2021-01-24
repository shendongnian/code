    var students = db.Student.GroupBy(i => i.Name)
						  .Select(g => new Student()
							{
								Name = g.Key,
								Status = g.Max(row => row.Status),
								Id = g.Max(row => row.Id)
							}).ToList();
    return View(students);
