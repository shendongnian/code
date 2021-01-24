    [ResponseType(typeof(IEnumerable<Student>))]
    public IHttpActionResult GetStudentsByName(string Name)
    {    
        var students = db.Students.Where(t => t.Name == Name).ToList();
    
        return students.Count == 0 ? NotFound() : Ok(students);
    }
