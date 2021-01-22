    public class MyClass
    {
        private readonly IRequestInfo _request;
        public MyClass(IRequestInfo request)
        {
            _request = request;
        }
        
        public ActionResult List(int page)
        {
            var viewModel = GetListViewModel(page);
            if (_request.IsAjaxRequest)
            {
                return PartialView("_list", viewModel);
            }
            return View("PartsList", viewModel);
        }
    }
