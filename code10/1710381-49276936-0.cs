    [ResponseType(typeof(IEnumerable<Student>))]
    public IHttpActionResult GetStudentsByName(string Name)
    {
    
        var students = db.Students.Where(t => t.Name == Name);
    
        return students == Enumerable.Empty<Student>() ? NotFound() : Ok(students);
    }
