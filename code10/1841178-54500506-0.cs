    public class ChatsController : Controller
    {
      public ActionResult Index()
        {
              using (ApplicationDbContext db = new ApplicationDbContext())
              {
                var chats = db.Set<Chat>().ToList();
                return PartialView("_Index", chats);
              }
        }
    }
