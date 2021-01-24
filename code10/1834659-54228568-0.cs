     public IActionResult Create()
        {
            var teachers = from s in _context.Teacher
                           where s.Class == null
                           select s;
            ViewData["Teachers"] = new SelectList(teachers.ToList(),"ID","FullName");
            return View();
        }
