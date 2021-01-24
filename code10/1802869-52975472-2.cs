    public async Task<ActionResult> Organization(string selectedOrg, string oauth)
    {
        IndexViewModel model = new IndexViewModel();
        // I have no idea where model came from so
        // this appears to block "unit-testing"
        // strange that you don't validate `selectedOrg`, you just use it
        model.Organizations = OrganizationData.Data;
        if (selectedOrg == null)
        {
            selectedOrg = model.Organizations.FirstOrDefault().OrgName;
        }
        else
        {
            model.SelectedOrg = selectedOrg;
        }
        // no idea where `_cache` came from so 
        // also appears to block "unit-testing"
        // As does `HttpContext` because you aren't using the
        // Interface
        var token = _cache.Get<TokenModel>("Token" + HttpContext.Session.GetString("TokenGuid"));
        oauth = token.AccessToken;
        try
        {
            var orgInfo = _azureAPI.GetOrgAsync(selectedOrg, oauth);
            model.Projects = JsonConvert.DeserializeObject<ProjectsModel>(orgInfo);
            // return a view here???
            return View("Index", model);
        }
        catch(Exception e)
        {
            // return JSON here instead????
            return Json(Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(e.ToString()));
        }
    }
