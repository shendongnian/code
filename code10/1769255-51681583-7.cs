    public ActionResult Create(StudentAttendanceTakersVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        // loop through model.Students to get the ID of the Student and its selected AttendanceTaker
        // initialize the data models and save to the database
        return RedirectToAction("Index");
    }
