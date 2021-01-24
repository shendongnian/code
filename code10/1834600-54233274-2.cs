    [HttpGet]
    [ServiceFilter(typeof(CompanyFilter))]
    public ActionResult<IEnumerable<string>> Get()
    {
        return new string[] { ViewBag.ERPUrl };
    }
