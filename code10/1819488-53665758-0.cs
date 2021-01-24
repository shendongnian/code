	View:
		@if (Request.IsAuthenticated && User.IsInRole("Administrators"))
		{
			@Html.Partial("PartialView/_AdminUser");
		}
		else if (Request.IsAuthenticated && User.IsInRole("StandardUses"))
		{
			@Html.Partial("PartialView/_StandardUser");
		}
    
	Controller:
        [Authorize(Users = "Administrators,StandardUses")]
		public ActionResult Index()
		{
			return View();
		}
