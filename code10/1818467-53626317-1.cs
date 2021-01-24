    string name = string.Empty;
    using (DataControllers.AllocationJAEntities = new DataControllers.Allocation())
    {
        name = JAEntities.JOB_Header.Find(1)?.CustomerName;
    }
