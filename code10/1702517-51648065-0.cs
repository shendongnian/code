    public async Task<IActionResult> CtrlAction()
    {
        ...
        var result = // whatever object you want
        return StatusCode((int) HttpStatusCode.Unauthorized, result);
    }
