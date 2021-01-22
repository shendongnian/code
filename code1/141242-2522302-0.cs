    public IEnumerable<SelectListItem> GetStudents()
    {
        return from id in projectID
               from employee in Project.Load(int.Parse(id))
               select new SelectListItem
               {
                   Text = employee.ID.ToString(),
                   Value = employee.Name
               };
    }
