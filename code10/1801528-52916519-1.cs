    [HttpPost]
    public IActionResult SomeAction(...) {
    
        //...
    
        return StatusCode((int)HttpStatusCode.Unauthorized); //401
        //...
    }
