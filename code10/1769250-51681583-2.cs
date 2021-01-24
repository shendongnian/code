    public ActionResult Create()
    {
        var students = db.Students.Select(x => new StudentVM
        {
            ID = x.Id,
            Name = x.User.FirstName + " " + x.User.LastName // adjust as required
        }).ToList();
        var attendanceTakers = db.SessionAttendanceTakers.Select(x => new AttendanceTakerVM
        {
            ID = x.Id,
            Name = x.User.FirstName + " " + x.User.LastName // adjust as required    
        });
        StudentAttendanceTakersVM model = new StudentAttendanceTakersVM
        {
            Students = students,
            AttendanceTakers = attendanceTakers
        };
        return View(model);
    }
