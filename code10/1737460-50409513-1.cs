    [HttpGet]
    public IActionResult Get(System.Nullable<System.Guid> uid)
    {
        return GetMyModel(uid); //make sure you got it, oterhwise return a NotFound()
    }
    [HttpPost]
    public IActionResult Post(InputModel model)
    {
        _service.doMagicStuff();
        return Ok();
    }
