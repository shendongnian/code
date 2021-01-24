    [HttpPost]
    public async Task<IActionResult> Create(CreateMentorViewModel model)
    {
        ...
        myService.MyMethod(model.Image);
        ...
    }
