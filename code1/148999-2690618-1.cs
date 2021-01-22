    public class BaseController : Controller
    {
        public BaseController()
        {
            var catRepository = ...;
            ViewData["Categoriass"] = new SelectList(catRepository.FindAllCategorias().AsEnumerable(), "id", "nome", 3);
        }
    }
