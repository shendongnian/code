    [ResponseType(typeof(List<Student>))]
    public IHttpActionResult GetStudentByName(string Name)
    {
        var students = db.Students.Where(t => t.Name == Name).ToList();
        if (!students.any())
        {
            return NotFound();
        }
        return Ok(students);
    }
