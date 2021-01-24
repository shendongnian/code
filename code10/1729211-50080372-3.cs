    public ActionResult JobList()
    {
        var db = new CaliberCoachingContext();
        var careerInformationList = db.CareerInformations
                                      .Select(a=> new JobVm { PostName = a.PostName,
                                                              StartDate = a.StartDate,
                                                              Eligibility = a.Eligibility })
                                      .ToList();
        return View(careerInformationList);
    }
