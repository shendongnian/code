    [HttpPost]
    public async Task<ActionResult> DoSomething(PostViewModel model)
    {                    
        Task.Run(async () => await ComputeHeavyOperations());
        //the response should be returned immediatelly 
        return Json("Heavy operations have been triggered.");
    }
    
    private  async void ComputeHeavyOperations()
    {
        //execute some heavy operations; like encoding a video 
        // you can use Task here
    }
