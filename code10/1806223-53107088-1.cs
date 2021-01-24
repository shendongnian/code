     [HttpGet]
     public ActionResult SearchIndex()
        {
            return View();
        }
    [HttpPost,ActionName("Index")]
     public ActionResult SearchIndex(string option, string search)
        {
          if (option == "Name")
          {
            var a = db.Students.Where(x => x.StudentName == search || search == null);
            return View(a.ToList());
          }
          else if (option == "Gender")
          {
            return View(db.Students.Where(x => x.Gender == search).ToList());
          }
          else
          {
            return View(db.Students.Where(x => x.RegNo == search || search == null).ToList()) 
          }
        }
