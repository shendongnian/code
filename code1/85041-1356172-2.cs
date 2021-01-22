    [Authorize(Users = "Charles, Linus")]
    public class SomeController : Controller
    // Or
    [Authorize(Users = "Charles, Linus")]
    public ActionResult SomeAction()
