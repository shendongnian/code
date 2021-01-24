    IQueryable<StudentViewModel> students = repository.Students.Select(m => 
        new StudentViewModel
    {
        Id = m.Id,
        Name = m.Name + " " + m.Surname
    });
    if (!string.IsNullOrEmpty(query))
    {
        students = students.Where(m => m.Name.StartsWith(query));
    }
