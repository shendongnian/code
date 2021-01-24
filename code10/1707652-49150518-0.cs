    public async Task<ActionResult> Index()
    {
       RestCall rc = new RestCall();
       //rename method as @NightOwl88 says
       var result = await rc.DoRestCall("somestring", "somestring").ConfigureAwait(false); 
       // do something with result
       return View();
    }
