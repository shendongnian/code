    [Authorize(Roles = "Admin, User")]
    public class SomeController : Controller
    // Or
    [Authorize(Roles = "Admin, User")]
    public ActionResult SomeAction()
