    public ActionResult Branch(string branchname)
        {
            var db = new ApplicationDbContext();
            var model = new Model();
            var EnrollmentStudentGroups = db.EnrollmentStudentGroups
                                      .Where(x => x.BranchName == branchname)
                                      .GroupBy(x => new { x.BranchName, x.Name, x.A_Status })
                                      .Select(x => new
                                      {
                                          BranchName = x.FirstOrDefault().BranchName,
                                          Name = x.FirstOrDefault().Name,
                                          A_Status = x.Max(p => p.A_Status)
                                      }).ToList();
            foreach(var item in EnrollmentStudentGroups)
            {
                model.EnrollmentStudentGroups.Add(new EnrollmentStudentGroup
                {
                    A_Status = item.A_Status,
                    BranchName = item.BranchName,
                    Name = item.Name
                });
            }
            return View(model);
        }
