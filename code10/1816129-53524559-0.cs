        public ActionResult Logout()
		{
			Request.GetOwinContext().Authentication.SignOut();
			return Redirect("/");
		}
		public void SignoutCleanup(string sid)
		{
			var cp = (ClaimsPrincipal)User;
			var sidClaim = cp.FindFirst("sid");
			if (sidClaim != null && sidClaim.Value == sid)
			{
				Request.GetOwinContext().Authentication.SignOut("Cookies");
			}
		}
