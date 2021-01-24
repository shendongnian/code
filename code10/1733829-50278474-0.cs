    public JsonResult Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ProviderTypeMasterViewModel> ProviderTypeMasterList)
    {
        if (ModelState.IsValid)
        {
            foreach (var ProviderTypeMaster in ProviderTypeMasterList)
            {
                TblProviderTypeMaster ptm = new ProviderTypeMasterViewModel().ToModel(ProviderTypeMaster);
                if (_context.TblProviderTypeMasters.Any(p => p.ProviderTypeName == ProviderTypeMaster.ProviderTypeName))
                {
                     ModelState.AddModelError("ProviderTypeName", "ProviderType already exists");
                }
                else
                {
                    if (ProviderTypeMasterList != null)
                    {
                        string userID = GetUserID();
                        providerTypeMasterService.SaveProviderTypeMaster(ProviderTypeMaster, userID);
                    }
                }
            }
        }
    }
    return Json(results.ToDataSourceResult(request, ModelState));
