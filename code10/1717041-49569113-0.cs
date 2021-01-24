    public ActionResult Index(int id)
    {
        IEnumerable<Project.Model.MySalaryModel> staffWithTheirSalary = from staff in data.Staff
                join salary in data.Salary on staff.Id equals salary.Id
                select new Project.Model.MySalaryModel 
                {
                    Id = staff.Id,
                    Name = staff.Name,
                    Salary = salary.Value,
                };
    
        return View(staffWithTheirSalary);
    }
