    public ActionResult SearchIndex(string search)
    {
    var students = from s in db.Students
                       select s;
        if (!String.IsNullOrEmpty(search))
        {
            students = students.Where(s => s.StudentName.Contains(search)
                                   || s.Gender.Contains(search));
        }
    return View(students.ToList());
    
    }
 
