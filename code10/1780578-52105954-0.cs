    HttpPost("[action]")]
    //see that I put [FromBody]
    public IActionResult Add([FromBody]Model model)
    {
        //OK is one of several IActionResult 
        return OK(model);
    }
