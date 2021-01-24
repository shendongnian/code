	public class UsersController : Controller
	{
		private DBContext db = new DBContext();
		private User GetCurrentUser()
		{
			return db.Users.Where(m => m.username.Equals(User.Identity.Name)).FirstOrDefault();
		}
		
		public ActionResult Info()
		{
			var user = GetCurrentUser();
			return View(user);
		}
		public ActionResult Edit(int? id){
			var user = GetCurrentUser();
			if(user.id == id){
				return View(user);
			}
		}
	}
