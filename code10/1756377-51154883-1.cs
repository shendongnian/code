    [HttpPost]
    public IHttpActionResult Delete(int id)
    {
      var delete = Connection.dm.Student.FirstOrDefault(s => s.StudentID == id);
      if (delete != null) {
          Connection.dm.Student.Remove(delete);
          Connection.dm.SaveChanges();
          }
          return Ok(Models.db.test);
    }
