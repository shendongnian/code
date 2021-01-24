    [HttpGet]
    public ActionResult Branch(string branchname)
    {
            var model = new Model
            {
               EnrollmentStudentGroups = db.EnrollmentStudentGroup.Where(x => x.BranchName == branchname).GroupBy(x => new { x.BranchName, x.Name })
            }
            return View(model);
    }
