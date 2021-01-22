	public ActionResult Get(int intId, NameValue nvWeekNumber)
	{
		Type U = Utilities.GetReportType(intId);
		Type objResultType = typeof (ObjectResult<>).MakeGenericType(U);
		return Activator.CreateInstance(objResultType, new []{ReportManager.Instance.Get(intId, nvWeekNumber)});
	}
