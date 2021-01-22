    // Repository
    public interface IRepository
    {
        IQueryable<Location> GetLocations();
    }
    // Controller
    public ActionResult Locations(int? page)
    {
        return View(repository.GetLocations().AsPagination(page ?? 1, 10);
    }
