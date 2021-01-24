    [HttpPost]
    public ActionResult YourAddRecordMethod(YourRecord yourRecord)
    {
        // Your adding record code here
        
        HubContext context = GlobalHost.ConnectionManager.GetHubContext<GenteHub>();
        context.Clients.All.updateDatos();
    }
