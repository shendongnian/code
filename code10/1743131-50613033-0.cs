    public ActionResult Index()
    {
        return View()
    }
    [Route("user/{userId}")]
    public async Task<ActionResult> GetUser(int userId)
    {
        var vm = await _userService.GetVm();
        return PartialView("_JSRedirect", new JSRedirectViewModel() { Location = Url.Action("Index") });
    }
