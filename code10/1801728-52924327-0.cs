    //Save method which will be taking time.
    private void Save(CancellationToken ct)
    {
        if (ct.IsCancellationRequested)
                return;
        
        // Long running code of saving data.. 
    }
    public JsonResult TestActionMethod(bool test1, bool test2)
    {  
        object response = null;
        // some code
        // Initiating background work item to execute Save method.
        HostingEnvironment.QueueBackgroundWorkItem(ct => Save(ct));
        return Json(response, JsonRequestBehavior.AllowGet);
    }
