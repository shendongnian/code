    string name = string.Empty;
    using (DataControllers.AllocationJAEntities = new DataControllers.Allocation())
    {
        name = JAEntities.JOB_Header
                .Where(a => a.JobID == 1)
                .Select(x => x.CustomerName)
                .FirstOrDefault();
    }
