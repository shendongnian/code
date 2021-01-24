    public ActionResult GetRecords(int? classId, string name, bool isAll = false)
    {
        var allRecords = repository.Students;
        if (!isAll)
        {
            //Retrieve active records only
            allRecords = allRecords.Where(m => m.StatusId == 1);
        }
        if (!string.IsNullOrEmpty(name))
        {
            allRecords = allRecords.Where(m => m.Name.StartsWith(name));
        }
        if (classId.HasValue)
        {
            allRecords = allRecords.Where(m => m.ClassId == classId);
        }
        // other stuff
    }
