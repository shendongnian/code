    [HttpGet("test/{type}")]
    [ValidateActionParameters]
    public ActionResult GetSomeData([Range(0, 2)]byte type)
    {
        if (!ModelState.IsValid)
        {
           // isValid has correct value
        }
    }
