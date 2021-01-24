    public class ReportsController : Controller
    {
        protected IUnitOfWork UnitOfWork { get; set; }
    
        public ReportsController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    
        [HttpGet]
        public ActionResult CategoryByName()
        {
            var viewModel = new CategoryReportViewModel();
    
            this.SetFilters(viewModel);
    
            return View(viewModel);
        }
    
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CategoryByName(CategoryReportViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                this.SetData(viewModel);
            }
    
            this.SetFilters(viewModel);
    
            return View(viewModel);
        }
        private void SetFilters(CategoryReportViewModel viewModel)
        {
            // Do something.....
            UnitOfWork.....
        }
        
        private void SetData(CategoryReportViewModel viewModel)
        {
            // Do something.....
            Records = UnitOfWork.....
        }
    }
