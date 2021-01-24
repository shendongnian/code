    public JsonResult OnGet(string OrgCode)
    {
        OrgChartNodes = _db.OrgChartNodes
                        .Where(g => g.OrgCode.Equals(OrgCode))
                        .ToList();
        return new JsonResult(OrgChartNodes);
    }
