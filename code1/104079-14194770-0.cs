    public ActionResult Register(string button, string userName, string email, string password, string confirmPassword)
	{
	if (button == "cancel")
		return RedirectToAction("Index", "Home");
	...
