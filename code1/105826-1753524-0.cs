    		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Verify()
		{
			return View("Verify");
		}
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Verify(Guid? id)
		{
			if (ValidId(id))
			{
				return RedirectToAction("Index", "Dashboard");
			}
			return View("Verify");
		}
