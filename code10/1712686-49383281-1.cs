    [HttpGet]
    public IActionResult Index()
    {
        return Content(_pMyShardData.Message);
    }
    [HttpPut]
    public IActionResult SetMessage(string pMessage)
    {
        _pMyShardData.Message = pMessage;
        return NoContent();
    }
