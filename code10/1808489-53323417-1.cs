    public partial class ApproveController : Controller
    {
        public ActionResult MainWindow()
        {   
            if (TempData[IDX_ACTIONRESULT] != null)
                ViewBag.SavedMessage = TempData[IDX_ACTIONRESULT].ToString();
            //Build the rest of the view
            return View();
        }
    }
