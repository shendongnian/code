	public class YourController : Controller {
		public ActionResult TheAction() {
			ViewData["SessionTimeout"] = Request.Session.Timout;
			ViewData["SessionWillExpireOn"] = DateTime.Now.AddMinutes(Request.Session.Timeout);
			return View(info);
		}
	}
