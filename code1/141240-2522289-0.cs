    public IEnumerable<SelectListItem> GetStudents()
    {
        List<SelectListItem> result = new List<SelectListItem>();
        foreach (var id in projectID)
        {
            int intId = Convert.ToInt32(id);
            foreach( Employee emp in Project.Load(intId))
                result.Add(new SelectListItem
                {
                    Selected =  false,
                    Text = emp.ID.ToString(),
                    Value = emp.Name
                });
            return result.AsEnumerable();
        }
    }
