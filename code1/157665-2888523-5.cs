    public class NameOfStoredProcedureController : Controller
    {
        private readonly IRepository _repository;
        public NameOfStoredProcedureController(IRepository repository)
        {
            _repository = repository;
        }
        // Warning don't add this constructor. Use a DI framework instead.
        // This kind of constructors are called Poor Man DI (see http://www.lostechies.com/blogs/jimmy_bogard/archive/2009/07/03/how-not-to-do-dependency-injection-in-nerddinner.aspx)
        // for more info on why this is bad.
        public NameOfStoredProcedureController() : this(new RepositorySql())
        { }
    
        public ActionResult Index(int parameter)
        {
            var model = _repository.GetModel(parameter);
            // Use directly Json, no need to do the serialization manually
            return Json(model);
        }
    }
