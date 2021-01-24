    var students = db.Student.GroupBy(i => i.Name)
						  .Select(g => new Student()
							{
								Name = g.Key,
								Status = g.Max(row => row.Status)
							}).ToList();
    return View(students);
