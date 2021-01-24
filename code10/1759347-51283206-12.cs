            public ActionResult Branch(string branchname)
        {
            var db = new ApplicationDbContext();
            var model = new Model();
            var students = db.Students
                                      .Where(x => x.BranchName == branchname)
                                      .GroupBy(x => new { x.BranchName, x.Name, x.Currency, x.NoCart, x.NoAccount })
                                      .Select(x => new
                                      {
                                          BranchName = x.FirstOrDefault().BranchName,
                                          Name = x.FirstOrDefault().Name,
                                          A_Status = x.Max(p => p.A_Status),
                                          Currency = x.FirstOrDefault().Currency,
                                          NoCart = x.FirstOrDefault().NoCart,
                                          NoAccount = x.FirstOrDefault().NoAccount
                                      }).ToList();
            foreach (var item in students)
            {
                model.Students.Add(new Student
                {
                    A_Status = item.A_Status,
                    BranchName = item.BranchName,
                    Name = item.Name,
                    NoAccount = item.NoAccount,
                    NoCart = item.NoCart,
                    Currency = item.Currency
                });
            }
            return View(model);
        }
