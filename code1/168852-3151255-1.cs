    public ActionResult Get(int intId, NameValue nvWeekNumber)
    {
        Type U = Utilities.GetReportType(intId); // returns a Report1, Report2 type etc...
        // ReportManager.Instance.Get() should create a ReportDB instance.
        return new ObjectResult<object>(ReportManager.Instance.Get(), nvWeekNumber));
    }
