                    [HttpGet]
                    public ActionResult Branch(string branchname)
                    {
                            //Check stuff like permissions and something like that
                            var model = new Model
                            {
                               EnrollmentStudentGroups = db.EnrollmentStudentGroup
                                           .Where(x => x.BranchName == branchname)
                                           .GroupBy(x => new { x.BranchName, x.Name }) 
                                           .Select(x => new 
                                                   {
                                                      x.BranchName.First(),
                                                      x.Name.First(),
                                                      A_Status = Max(x.A_STATUS)
                                                    });
                             }
                            return View(model);
                    }
