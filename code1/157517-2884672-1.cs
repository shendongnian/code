	class RController : Controller
	{
		public ActionResult Event(int eventId)
		{
			Response.StatusCode = (int)HttpStatusCode.MovedPermanently;
			Response.RedirectLocation = Url.Action("Details", "Event", new { eventId = eventId });
			return null;
		}
		public ActionResult Register(int eventId)
		{
			Response.StatusCode = (int)HttpStatusCode.MovedPermanently;
			Response.RedirectLocation = Url.Action("Register", "Event", new { eventId = eventId });
			return null;
		}
	}
