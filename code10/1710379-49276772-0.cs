    [ResponseType(typeof(List<Student>))]
    public IHttpActionResult GetStudentByName(string Name)
    {
        Student students = db.Students.Where(t => t.Name == Name);
        if (!students.any())
        {
            return NotFound();
        }
        return Ok(students);
    }
