    [Route("/to/{email?}")]
    public IActionResult ToAction(string email)
    {
        return View("To", email);
    }
    [Route("/from")]
    public IActionResult FromAction()
    {
        ControllerContext.RouteData.Values.Add("email", "mike@myemail.com");
        return RedirectToAction(nameof(ToAction));
             // will redirect to /to/mike@myemail.com
    }
    [Route("/FromAnother/{email?}")]`
    public IActionResult FromAnotherAction(string email)
    {
        return RedirectToAction(nameof(ToAction));
             // will redirect to /to/<whatever the email param says>
             // no need to specify the route part explicitly
    }
