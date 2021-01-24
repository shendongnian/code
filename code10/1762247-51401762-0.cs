    class HomeController
    {
        private IStudentRepository _repository;
        public HomeController(IStudentRepository _repository)
        {
            //We don't know who instanciated the repo, but we don't care
            this._repository = _repository;
        }
        public JsonResult Index()
        {
            //We only know about the repo that it implements IStudentRepository
            //So we know we can call this method without a risk.
            var m= _repository.getAll();
            return Json(m,JsonRequestBehavior.AllowGet);
        }
    }
