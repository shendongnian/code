    [AllowAnonymous]
    public IActionResult Error()
    {
        //log your error here
        return View(new ErrorViewModel 
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
