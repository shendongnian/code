    public class UserController : Controller{
    private readonly IUserRepository _repos;
    public UserController(IUserRepository repo)
    {
        _repos = repo;
    }
    public ActionResult Index()
    {
        return RedirectToAction("Details");
    }
    public ActionResult Details()
    {
        IQueryable<Business.Entities.User> users = _repos.GetAll();
        return View("Details", users);
    }}
